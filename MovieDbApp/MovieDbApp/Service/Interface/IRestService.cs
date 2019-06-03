using MovieDbApp.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieDbApp.Service
{
    public interface IRestService
    {
        Task<MovieResponse> GetPopularMovies(int page);
        Task<MovieResponse> GetUpcomingMovies(int page);
        Task<MovieResponse> GetTopRatedMovies(int page);
        Task<List<Genre>> GetGenres();
    }
}
