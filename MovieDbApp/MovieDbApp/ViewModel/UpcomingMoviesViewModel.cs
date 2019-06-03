using MovieDbApp.Data;
using MovieDbApp.Service;
using System.Threading.Tasks;

namespace MovieDbApp.ViewModel
{
    public class UpcomingMoviesViewModel : InfiniteScrollViewModel
    {
        public override string Title => "Upcoming Movies";

        public UpcomingMoviesViewModel(IRestService service) : base(service) { }

        public override async Task<MovieResponse> GetRemoteData()
        {
            return await service.GetUpcomingMovies(page);
        }
    }
}
