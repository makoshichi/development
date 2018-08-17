﻿using MovieDbApp.View;
using System;

namespace MovieDbApp.MoviesSorting
{
    public class UpcomingMovies : BaseCategory
    {
        public override string DisplayName => "Upcoming";

        public override Type PageType => typeof(UpcomingMoviesPage);
    }
}