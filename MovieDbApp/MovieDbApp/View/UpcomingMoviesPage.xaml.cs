using MovieDbApp.Service;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MovieDbApp.ViewModel;
using MovieDbApp.Entities;

namespace MovieDbApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UpcomingMoviesPage : ContentPage
	{
        private UpcomingMoviesViewModel viewModel;

		public UpcomingMoviesPage()
		{
			InitializeComponent();
            viewModel = new UpcomingMoviesViewModel(new MovieService());
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