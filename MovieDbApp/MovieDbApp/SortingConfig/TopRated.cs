using MovieDbApp.View;
using System;

namespace MovieDbApp.SortingConfig
{
    public class TopRated : BaseCategory
    {
        public override string DisplayName => "Top Rated";

        public override Type PageType => typeof(PageNotFound);
    }
}
