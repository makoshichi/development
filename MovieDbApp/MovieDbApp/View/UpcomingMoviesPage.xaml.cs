﻿using MovieDbApp.Service;
using MovieDbApp.Model;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MovieDbApp.ViewModel;

namespace MovieDbApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MoviesPage : ContentPage
	{
        private UpcomingMoviesViewModel viewModel;

		public MoviesPage()
		{
			InitializeComponent();
            viewModel = new UpcomingMoviesViewModel();
            BindingContext = viewModel;
            listView.ItemTapped += ListView_ItemTapped;
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var upcoming = await viewModel.GetUpcomingMovies();

            if (upcoming == null)
                await DisplayAlert("Communication Error", "An error has occurred while trying to communicate with the REST API", "OK");
            else
                listView.ItemsSource = upcoming;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new MovieDetailsPage((Movie)e.Item));
        }
    }
}