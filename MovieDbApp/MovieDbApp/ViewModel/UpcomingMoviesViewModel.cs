using MovieDbApp.Entities;
using MovieDbApp.Helper;
using MovieDbApp.Model;
using MovieDbApp.Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace MovieDbApp.ViewModel
{
    // implement an abstract ViewModelBase to make InfiniteScroll generic
    public class UpcomingMoviesViewModel//: INotifyPropertyChanged
    {
        private readonly int scrollingThreshold = 15;
        private int loadStartIndex;
        private int totalResults;
        private int totalPages;
        private int page;

        public ObservableCollection<Movie> Movies { get; private set; }

        private IRestService service;

        //public event PropertyChangedEventHandler PropertyChanged;

        public string Title { get { return "Upcoming Movies"; } }

        public UpcomingMoviesViewModel(IRestService service)
        {
            loadStartIndex = scrollingThreshold;
            page = 1;
            Movies = new ObservableCollection<Movie>();
            this.service = service;
        }

        public async Task<bool> LoadUpcomingMovies()
        {
            var upcoming = await service.GetUpcomingMovies(page);
            var allGenres = await service.GetGenres();

            if (upcoming == null)
                return false;

            ConvertToMovieList(upcoming, allGenres);
            return true;
        }

        public async Task<bool> LoadMoreMovies(Movie e)
        {

            if (e.Position < loadStartIndex)
                return true;

            loadStartIndex = scrollingThreshold + Movies.Count;
            page++;

            // Loading Popup (signaled task) -> do it the old-fashioned way, then try async/await

            return await LoadUpcomingMovies();
        }

        // Maybe this belongs somewhere else
        private void ConvertToMovieList(UpcomingModel upcoming, List<Genre> allGenres) // I needed to reference Model from ViewModel here for infinite scrolling purposes
        {
            totalPages = upcoming.total_pages;
            totalResults = upcoming.total_results;
            int totalPagesInResponse = upcoming.results.Count;

            for (int i = 0; i < totalPagesInResponse; i++)
            {
                var movie = (Movie)upcoming.results[i];
                movie.DisplayGenre = GenreProcessor.ConvertToDisplayGenre(movie.GenreIds, allGenres); // Converts GenreIds[] to UI-friendly string 
                movie.Position = page == 1 ? i : i  + totalPagesInResponse * (page - 1); // Position used in infinite scrolling
                Movies.Add(movie);
            }

            //foreach (var result in upcoming.results)
            //{
            //    var movie = (Movie)result;
            //    movie.DisplayGenre = GenreProcessor.ConvertToDisplayGenre(movie.GenreIds, allGenres); // Converts GenreIds[] to UI-friendly string
            //    Movies.Add(movie);
            //}
        }
    }
}
