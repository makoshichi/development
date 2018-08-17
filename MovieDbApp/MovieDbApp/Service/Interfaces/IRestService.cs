using MovieDbApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieDbApp.Service
{
    public interface IRestService
    {
        Task<UpcomingModel> GetUpcomingMovies(int page);
        Task<List<Genre>> GetGenres();
    }
}
