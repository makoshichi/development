using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDbApp.SortingConfig
{
    public abstract class BaseCategory
    {
        public abstract string DisplayName { get; }
        public abstract Type PageType { get; }
    }
}
