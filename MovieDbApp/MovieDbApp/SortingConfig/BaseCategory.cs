using System;

namespace MovieDbApp.SortingConfig
{
    public abstract class BaseCategory
    {
        public abstract string DisplayName { get; }
        public abstract Type PageType { get; }
    }
}
