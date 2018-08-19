using MovieDbApp.View;
using System;

namespace MovieDbApp.MoviesSorting
{
    public class TopRated : ISortingCategory
    {
        public string DisplayName => "Top Rated";

        public Type PageType => typeof(PageNotFound);
    }
}
