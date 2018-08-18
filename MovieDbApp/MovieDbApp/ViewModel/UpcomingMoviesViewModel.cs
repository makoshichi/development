using MovieDbApp.Entities;
using MovieDbApp.Helper;
using MovieDbApp.Model;
using MovieDbApp.Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MovieDbApp.ViewModel
{
    public class UpcomingMoviesViewModel : InfiniteScrollViewModel
    {
        private IRestService service;

        public string Title { get { return "Upcoming Movies"; } }

        public UpcomingMoviesViewModel(IRestService service)
        {
            loadStartIndex = scrollingThreshold;
            page = 1;
            Movies = new ObservableCollection<Movie>();
            this.service = service;
        }

        public override async Task<bool> LoadMovies()
        {
            var upcoming = await service.GetUpcomingMovies(page);
            var allGenres = await service.GetGenres();

            if (upcoming == null)
                return false;

            ConvertToMovieList(upcoming, allGenres);
            return true;
        }

        // I couldn't generalize it further
        protected override void ConvertToMovieList(IJsonModel model, List<Genre> allGenres)
        {
            var upcoming = (UpcomingModel)model;
            totalPages = upcoming.total_pages;
            totalResults = upcoming.total_results;
            int totalPagesInResponse = upcoming.results.Count;

            for (int i = 0; i < totalPagesInResponse; i++)
            {
                var movie = (Movie)upcoming.results[i];
                movie.DisplayGenre = GenreProcessor.ConvertToDisplayGenre(movie.GenreIds, allGenres); // Converts GenreIds[] to UI-friendly string 
                movie.Position = page == 1 ? i : i + totalPagesInResponse * (page - 1); // Position used in infinite scrolling
                Movies.Add(movie);
            }
        }
    }
}
