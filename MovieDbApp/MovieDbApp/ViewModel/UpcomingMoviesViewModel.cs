using MovieDbApp.Entities;
using MovieDbApp.Helper;
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
            List<Movie> movies = new List<Movie>();
            var upcoming = await service.GetUpcomingMovies(page);
            var allGenres = await service.GetGenres();

            if (upcoming == null)
                return null;

            // Move it to movie service?
            foreach (var result in upcoming.results) 
            {
                var movie = (Movie)result;
                movie.DisplayGenre = GenreProcessor.ConvertToDisplayGenre(movie.GenreIds, allGenres);
                movies.Add(movie);
            }

            return movies;
        }
    }
}
