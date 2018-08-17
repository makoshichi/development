using MovieDbApp.Category;
using MovieDbApp.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MovieDbApp.ViewModel
{
    public class SortingCategoryViewModel
    {
        private INavigation navigation;

        public List<BaseCategory> Categories { get; private set; }

        public SortingCategoryViewModel(INavigation navigation)
        {
            this.navigation = navigation;
            Categories = new List<BaseCategory>() { new UpcomingMovies() };
        }

        public void Route(BaseCategory category)
        {
            var pageType = category.PageType;
            var page = Activator.CreateInstance(pageType);
            navigation.PushAsync((Page)page);
        }
    }
}
