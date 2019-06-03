using MovieDbApp.View;
using System;

namespace MovieDbApp.MoviesSorting
{
    public class UpcomingMovies : IMovieMenu
    {
        public string DisplayName => "Upcoming";

        public Type PageType => typeof(UpcomingMoviesPage);
    }
}
