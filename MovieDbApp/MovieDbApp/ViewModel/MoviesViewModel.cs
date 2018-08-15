using MovieDbApp.Model;
using MovieDbApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDbApp.ViewModel
{
    public class MoviesViewModel
    {
        private int page = 1;

        public async Task<List<Movie>> GetUpcomingMovies()
        {
            var upcoming = await new RestService().GetUpcomingMovies(page);

            if (upcoming == null)
                return null;

            return upcoming.results.Select(r => (Movie)r).ToList();
        }
    }
}
