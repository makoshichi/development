using MovieDbApp.Entities;
using MovieDbApp.Helper;
using MovieDbApp.Service;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MovieDbApp.ViewModel
{
    // implement an abstract ViewModelBase to make InfiniteScroll generic
    public class UpcomingMoviesViewModel//: INotifyPropertyChanged
    {
        private readonly int scollingThreshold = 15;
        private int loadStartIndex;
        private int page;

        public ObservableCollection<Movie> Movies { get; private set; }

        private IRestService service;

        //public event PropertyChangedEventHandler PropertyChanged;

        public string Title { get { return "Upcoming Movies"; } }

        public UpcomingMoviesViewModel(IRestService service)
        {
            loadStartIndex = scollingThreshold - 1;
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

            ConvertToBindableData(upcoming, allGenres);
            return true;
        }

        public async Task<bool> LoadMoreMovies(Movie e)
        {

            if (e.Position != loadStartIndex)
                return true;

            loadStartIndex = scollingThreshold + Movies.Count;
            page++;

            // Loading Popup (signaled task) -> do it the old-fashioned way, then try async/await

            return await LoadUpcomingMovies();
        }

        // Maybe this belongs somewhere else
        private void ConvertToBindableData(List<Movie> upcoming, List<Genre> allGenres)
        {
            int totalPagesInResponse = upcoming.Count;

            for (int i = 0; i < totalPagesInResponse; i++)
            {
                var movie = upcoming[i];
                movie.DisplayGenre = GenreProcessor.ConvertToDisplayGenre(movie.GenreIds, allGenres); // Converts GenreIds[] to UI-friendly string 
                movie.Position = page == 1 ? i : i  + totalPagesInResponse * (page - 1); // Position used in infinite scrolling
                Movies.Add(movie);
            }
        }
    }
}
