using System;

namespace MovieDbApp.MoviesSorting
{
    public abstract class BaseCategory
    {
        public abstract string DisplayName { get; }
        public abstract Type PageType { get; }
    }
}
