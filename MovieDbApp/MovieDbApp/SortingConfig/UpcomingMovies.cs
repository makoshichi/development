using MovieDbApp.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDbApp.SortingConfig
{
    public class UpcomingMovies : BaseCategory
    {
        //public override string Title => "Upcoming Movies";

        public override string Name => "Upcoming";

        public override Type PageType => typeof(UpcomingMoviesPage);
    }
}
