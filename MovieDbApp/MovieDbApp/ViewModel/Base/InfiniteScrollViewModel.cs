using MovieDbApp.Data;
using MovieDbApp.Helper;
using MovieDbApp.Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MovieDbApp.ViewModel
{
    public abstract class InfiniteScrollViewModel : INotifyPropertyChanged
    {
        protected IRestService service;
        public abstract string Title { get; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected int loadStartIndex;
        protected int page;
        protected int totalResults;
        protected int totalPages;
        protected bool _isBusy;

        private int scrollingCycle = 1;
        private int position;

        public InfiniteScrollViewModel(IRestService service)
        {
            page = 1;
            Movies = new ObservableCollection<Movie>();
            this.service = service;
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsBusy)));
            }
        }

        public ObservableCollection<Movie> Movies { get; protected set; }

        public abstract Task<MovieResponse> GetRemoteData();

        public async Task<bool> LoadMovies()
        {
            IsBusy = true;
            var jsonResult = await GetRemoteData();
            var allGenres = await service.GetGenres();
            IsBusy = false;

            if (jsonResult == null)
                return false;

            ConvertToMovieList(jsonResult, allGenres);
            return true;
        }

        public async Task<bool> LoadMoreMovies(Movie e)
        {
            position = e.Position;
            Debug.WriteLine($"Position: {position}e.Position: {e.Position}; loadStartIndex: {loadStartIndex}");

            if (position < loadStartIndex) // The framework seems to be inducing a bug. I don't have the willpower to fix it right now, but it happens after around 250 entries of scrolling.
                return true;

            loadStartIndex = Movies.Count * scrollingCycle;
            page++;
            scrollingCycle++;
            IsBusy = true;
            bool resultOk = await LoadMovies();
            IsBusy = false;

            return resultOk;
        }

        protected void ConvertToMovieList(MovieResponse response, List<Genre> allGenres)
        {
            totalPages = response.total_pages;
            totalResults = response.total_results;
            int totalPagesInResponse = response.results.Count;

            for (int i = 0; i < totalPagesInResponse; i++)
            {
                var movie = (Movie)response.results[i];
                movie.DisplayGenre = GenreProcessor.ConvertToDisplayGenre(movie.GenreIds, allGenres); // Converts GenreIds[] to UI-friendly string 
                movie.Position = page == 1 ? i : i + totalPagesInResponse * (page - 1); // Position used in infinite scrolling
                Movies.Add(movie);
            }
        }

    }
}
