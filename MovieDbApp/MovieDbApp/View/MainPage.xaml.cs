﻿using MovieDbApp.Navigation;
using System;
using Xamarin.Forms;

namespace MovieDbApp.View
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            masterPage.ListView.ItemSelected += OnItemSelected;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType)) { BarBackgroundColor = Color.FromHex("#01D277") };
                masterPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
