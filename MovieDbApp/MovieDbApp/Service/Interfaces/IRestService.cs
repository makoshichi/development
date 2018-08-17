using MovieDbApp.Entities;
using MovieDbApp.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieDbApp.Service
{
    public interface IRestService
    {
        Task<UpcomingModel> GetUpcomingMovies(int page);
        Task<List<Genre>> GetGenres();
    }
}
