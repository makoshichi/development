using System;

namespace MovieDbApp.MoviesSorting
{
    public interface IMovieMenu
    {
        string DisplayName { get; }
        Type PageType { get; }
    }
}
