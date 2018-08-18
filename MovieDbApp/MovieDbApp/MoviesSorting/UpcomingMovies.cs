using MovieDbApp.View;
using System;

namespace MovieDbApp.MoviesSorting
{
    public class UpcomingMovies : ISortingCategory
    {
        public string DisplayName => "Upcoming";

        public Type PageType => typeof(UpcomingMoviesPage);
    }
}
