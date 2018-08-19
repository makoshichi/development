using System;

namespace MovieDbApp.MoviesSorting
{
    public interface ISortingCategory
    {
        string DisplayName { get; }
        Type PageType { get; }
    }
}
