using MovieDbApp.Entities;
using MovieDbApp.Helper;
using MovieDbApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MovieDbApp.ViewModel
{
    public abstract class InfiniteScrollViewModel
    {
        protected readonly int scrollingThreshold = 5;
        protected int loadStartIndex;
        protected int page;
        protected int totalResults;
        protected int totalPages;

        public ObservableCollection<Movie> Movies { get; protected set; }

        public abstract Task<bool> LoadMovies();

        public async Task<bool> LoadMoreMovies(Movie e)
        {

            if (e.Position < loadStartIndex)
                return true;

            loadStartIndex = scrollingThreshold + Movies.Count;
            page++;

            // Loading Popup (signaled task) -> do it the old-fashioned way, then try async/await

            return await LoadMovies();
        }

        protected abstract void ConvertToMovieList(IJsonModel model, List<Genre> allGenres);
    }
}
