using MovieDbApp.Entities;
using MovieDbApp.Model;
using MovieDbApp.Model;
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected readonly int scrollingThreshold = 10;

        protected IRestService service;
        protected int loadStartIndex;
        protected int page;
        protected int totalResults;
        protected int totalPages;
        protected bool _isBusy;
        private int scrollingCycle = 1;
        private int position;
        
        public abstract string Title { get; }

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

        public abstract Task<bool> LoadMovies();

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

        protected abstract void ConvertToMovieList(IJsonModel model, List<Genre> allGenres);
    }
}
