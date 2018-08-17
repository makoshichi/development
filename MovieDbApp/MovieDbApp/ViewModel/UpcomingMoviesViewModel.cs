using MovieDbApp.Entities;
using MovieDbApp.Helper;
using MovieDbApp.Model;
using MovieDbApp.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieDbApp.ViewModel
{
    public class UpcomingMoviesViewModel
    {
        private int page;
        private IRestService service;

        public string Title { get { return "Upcoming Movies"; } }

        public UpcomingMoviesViewModel(IRestService service)
        {
            page = 1;
            this.service = service;
        }

        public async Task<List<Movie>> GetUpcomingMovies()
        {
 
            var upcoming = await service.GetUpcomingMovies(page);
            var allGenres = await service.GetGenres();

            if (upcoming == null)
                return null;

            page++;

            return TypeConverter(upcoming, allGenres);
        }

        // Maybe this belongs somewhere else
        private List<Movie> TypeConverter(UpcomingModel upcoming, List<Genre> allGenres) // I needed to reference Model from ViewModel here for infinite scrolling purposes
        {
            List<Movie> movies = new List<Movie>();

            foreach (var result in upcoming.results)
            {
                var movie = (Movie)result;
                movie.DisplayGenre = GenreProcessor.ConvertToDisplayGenre(movie.GenreIds, allGenres); // Converts GenreIds[] to UI-friendly string
                movies.Add(movie);
            }

            return movies;
        }
    }
}
