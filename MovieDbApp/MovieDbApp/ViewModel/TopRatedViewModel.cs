using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieDbApp.Entities;
using MovieDbApp.Model;
using MovieDbApp.Service;

namespace MovieDbApp.ViewModel
{
    public class TopRatedViewModel : InfiniteScrollViewModel
    {
        public override string Title => throw new NotImplementedException();

        public TopRatedViewModel(IRestService service) : base(service)
        {
        }

        public override Task<bool> LoadMovies()
        {
            throw new NotImplementedException();
        }

        protected override void ConvertToMovieList(IJsonModel model, List<Genre> allGenres)
        {
            throw new NotImplementedException();
        }
    }
}
