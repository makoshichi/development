using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieDbApp.Data;
using MovieDbApp.Service;

namespace MovieDbApp.ViewModel
{
    public class TopRatedViewModel : InfiniteScrollViewModel
    {
        public override string Title => "Top Rated Movies";

        public TopRatedViewModel(IRestService service) : base(service) { }

        public override async Task<MovieResponse> GetRemoteData()
        {
            return await service.GetTopRatedMovies(page);
        }
    }
}
