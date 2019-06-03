using MovieDbApp.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDbApp.MoviesSorting
{
    class PopularMovies : IMovieMenu
    {
        public string DisplayName => "Popular Movies";

        public Type PageType => typeof(PopularMoviesPage);
    }
}
