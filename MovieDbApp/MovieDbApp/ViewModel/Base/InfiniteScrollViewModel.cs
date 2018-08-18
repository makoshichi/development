using MovieDbApp.Entities;
using MovieDbApp.Helper;
using MovieDbApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace MovieDbApp.ViewModel
{
    public abstract class InfiniteScrollViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected readonly int scrollingThreshold = 1;
        protected int loadStartIndex;
        protected int page;
        protected int totalResults;
        protected int totalPages;
        protected bool _isBusy;

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
            if (e.Position < loadStartIndex)
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
