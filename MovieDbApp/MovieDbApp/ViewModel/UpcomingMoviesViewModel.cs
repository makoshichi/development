using MovieDbApp.Entities;
using MovieDbApp.Model;
using MovieDbApp.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieDbApp.ViewModel
{
    public class UpcomingMoviesViewModel : InfiniteScrollViewModel
    {
        public override string Title => "Upcoming Movies"; 

        public UpcomingMoviesViewModel(IRestService service) : base(service) { }

        public override async Task<bool> LoadMovies()
        {

            IsBusy = true;
            var upcoming = await service.GetUpcomingMovies(page);
            var allGenres = await service.GetGenres();
            IsBusy = false;

            if (upcoming == null)
                return false;

            ConvertToMovieList(upcoming, allGenres);
            return true;
        }

        protected override void ConvertToMovieList(IJsonModel model, List<Genre> allGenres)
        {
            var upcoming = (UpcomingModel)model;
            totalPages = upcoming.total_pages;
            totalResults = upcoming.total_results;
            int totalPagesInResponse = upcoming.results.Count;

            for (int i = 0; i < totalPagesInResponse; i++)
            {
                var movie = (Movie)upcoming.results[i];
                movie.DisplayGenre = movie.ConvertToDisplayGenre(allGenres); // Converts GenreIds[] to UI-friendly string 
                movie.Position = page == 1 ? i : i + totalPagesInResponse * (page - 1); // Position used in infinite scrolling
                Movies.Add(movie);
            }
        }
    }
}
