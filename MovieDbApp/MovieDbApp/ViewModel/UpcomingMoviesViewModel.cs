using MovieDbApp.Helper;
using MovieDbApp.Model;
using MovieDbApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDbApp.ViewModel
{
    public class UpcomingMoviesViewModel
    {
        private int page = 1;

        public async Task<List<Movie>> GetUpcomingMovies()
        {
            List<Movie> movies = new List<Movie>();
            RestService service = new RestService();
            var upcoming = await service.GetUpcomingMovies(page);
            var allGenres = await service.GetGenres();

            if (upcoming == null)
                return null;

            foreach(var result in upcoming.results)
            {
                var movie = (Movie)result;
                movie.DisplayGenre = GenreProcessor.ConvertToDisplayGenre(movie.GenreIds, allGenres);
                movies.Add(movie);
            }

            return movies;
        }
    }
}
