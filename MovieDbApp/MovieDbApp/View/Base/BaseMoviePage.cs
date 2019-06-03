using MovieDbApp.Data;
using MovieDbApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MovieDbApp.View.Base
{
    public class BaseMoviePage : ContentPage
    {
        protected InfiniteScrollViewModel viewModel;

        protected virtual void OnAppearing()
        {
            //base.OnAppearing();

            //var resultOk = await viewModel.LoadMovies();
            //if (!resultOk)
            //    await DisplayAlert("Communication Error", "An error has occurred while trying to communicate with the REST API", "OK");
        }

        protected void ListViewItemTapped(object sender, ItemTappedEventArgs e, ListView listView)
        {
            Navigation.PushAsync(new MovieDetailsPage((Movie)e.Item));
            listView.SelectedItem = null;
        }
    }
}
