using MovieDbApp.MoviesSorting;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MovieDbApp.ViewModel
{
    public class MoviesSortingPage
    {
        private INavigation navigation;

        public List<BaseCategory> Categories { get; private set; }

        public MoviesSortingPage(INavigation navigation)
        {
            this.navigation = navigation;
            CreateCategories();
        }

        public void Navigate(BaseCategory category)
        {
            var page = Activator.CreateInstance(category.PageType);
            navigation.PushAsync((Page)page);
        }

        private void CreateCategories()
        {
            Categories = new List<BaseCategory>()
            {
                new UpcomingMovies(),
                new TopRated()
            };
        }
    }
}
