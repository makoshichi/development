using MovieDbApp.View;
using System;

namespace MovieDbApp.MoviesSorting
{
    public class TopRatedMovies : IMovieMenu
    {
        public string DisplayName => "Top Rated";

        public Type PageType => typeof(TopRatedPage);
    }
}
