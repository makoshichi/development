using MovieDbApp.Entities;
using MovieDbApp.Helper;
using MovieDbApp.Model;
using MovieDbApp.Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System;
using Xamarin.Forms;
using System.IO;
using System.Net.Http;

namespace MovieDbApp.ViewModel
{
    public class UpcomingMoviesViewModel : InfiniteScrollViewModel
    {
        private IRestService service;

        public string Title { get { return "Upcoming Movies"; } }

        public UpcomingMoviesViewModel(IRestService service) : base()
        {
            loadStartIndex = scrollingThreshold;
            page = 1;
            Movies = new ObservableCollection<Movie>();
            this.service = service;
        }

        public override async Task<bool> LoadMovies()
        {

            IsBusy = true;
            var upcoming = await service.GetUpcomingMovies(page);
            var allGenres = await service.GetGenres();
            IsBusy = false;

            if (upcoming == null)
            {
                
                return false;
            }

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

        //TEST
        //public class AsyncImageService
        //{
        //    private bool isLoading;

        //    public async Task<ImageSource> LoadImage(string imageUrl, ImageSource target)
        //    {
        //        Stream stream;
        //        ImageSource imageSource = null;
        //        if (!isLoading)
        //        {
        //            isLoading = true;
        //            if (!string.IsNullOrEmpty(imageUrl))
        //            {
        //                HttpClient client = new HttpClient();
        //                var uri = new Uri(imageUrl);
        //                stream = await client.GetStreamAsync(uri);
        //                imageSource = ImageSource.FromStream(() => stream);
        //            }
        //        }
        //        isLoading = false;

        //        return imageSource;
        //    }
        //}
    }
}
