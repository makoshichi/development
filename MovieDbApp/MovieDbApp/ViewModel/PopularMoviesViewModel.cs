using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MovieDbApp.Data;
using MovieDbApp.Service;

namespace MovieDbApp.ViewModel
{
    public class PopularMoviesViewModel : InfiniteScrollViewModel
    {
        public override string Title => "Popular Movies";

        public PopularMoviesViewModel(IRestService service) : base(service) { }

        public override async Task<MovieResponse> GetRemoteData()
        {
            return await service.GetPopularMovies(page);
        }
    }
}
