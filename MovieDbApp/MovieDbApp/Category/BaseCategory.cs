using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDbApp.Category
{
    public abstract class BaseCategory
    {
        //public abstract string Title { get; }
        public abstract string Name { get; }
        public abstract Type PageType { get; }
    }
}
