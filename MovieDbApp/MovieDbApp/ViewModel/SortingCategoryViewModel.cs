﻿using MovieDbApp.SortingConfig;
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
            Categories = new List<BaseCategory>() { new UpcomingMovies() }; // Figure out a better way to configure categories...
        }

        public void Route(BaseCategory category)
        {
            var page = Activator.CreateInstance(category.PageType);
            navigation.PushAsync((Page)page);
        }
    }
}
