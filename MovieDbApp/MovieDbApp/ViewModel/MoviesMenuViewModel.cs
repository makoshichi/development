using MovieDbApp.MoviesSorting;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MovieDbApp.ViewModel
{
    public class MoviesMenuViewModel
    {
        private INavigation navigation;

        public List<IMovieMenu> Categories { get; private set; }

        public MoviesMenuViewModel(INavigation navigation)
        {
            this.navigation = navigation;
            CreateCategories();
        }

        public void Navigate(IMovieMenu category)
        {
            var page = Activator.CreateInstance(category.PageType);
            navigation.PushAsync((Page)page);
        }

        private void CreateCategories()
        {
            Categories = new List<IMovieMenu>()
            {
                new UpcomingMovies(),
                new TopRatedMovies(),
                new PopularMovies()
            };
        }
    }
}
