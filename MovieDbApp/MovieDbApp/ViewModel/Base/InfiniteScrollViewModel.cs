using MovieDbApp.Entities;
using MovieDbApp.Helper;
using MovieDbApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace MovieDbApp.ViewModel
{
    public abstract class InfiniteScrollViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected readonly int scrollingThreshold = 10;
        protected int loadStartIndex;
        protected int page;
        protected int totalResults;
        protected int totalPages;
        protected bool _isBusy;

        private int position;

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

            loadStartIndex = scrollingThreshold + Movies.Count;
            page++;
            IsBusy = true;
            bool resultOk = await LoadMovies();
            IsBusy = false;

            return resultOk;
        }

        protected abstract void ConvertToMovieList(IJsonModel model, List<Genre> allGenres);
    }
}
