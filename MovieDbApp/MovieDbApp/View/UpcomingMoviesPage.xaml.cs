using MovieDbApp.Service;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MovieDbApp.ViewModel;
using MovieDbApp.Data;

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
            listView.ItemAppearing += ListView_ItemAppearing;
		}

        // Not my best work in display here
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var resultOk = await viewModel.LoadMovies();
            if (!resultOk)
                await DisplayAlert("Communication Error", "An error has occurred while trying to communicate with the REST API", "OK");
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new MovieDetailsPage((Movie)e.Item));
            listView.SelectedItem = null;
        }

        private async void ListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var resultOk = await ((UpcomingMoviesViewModel)BindingContext).LoadMoreMovies((Movie)e.Item);
            if (!resultOk)
                await DisplayAlert("Communication Error", "An error has occurred while trying to communicate with the REST API", "OK");
        }
    }
}