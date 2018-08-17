using MovieDbApp.Entities;
using MovieDbApp.Model;
using MovieDbApp.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieDbApp.Service
{
    public interface IRestService
    {
        AsyncImageService ImageService { get; }

        Task<List<Movie>> GetUpcomingMovies(int page);
        Task<List<Genre>> GetGenres();
    }
}
