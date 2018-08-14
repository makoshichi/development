using MovieDbApp.Data;
using MovieDbApp.Model;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovieDbApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MoviesPage : ContentPage
	{
        private int page = 1;

		public MoviesPage()
		{
			InitializeComponent();
            //listView.ItemsSource = new List<string>() { "Avengers Infinity War" };
            listView.ItemTapped += ListView_ItemTapped;
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var upcoming = await new RestService().GetUpcomingMovies(page);

            if (upcoming == null)
            {
                await DisplayAlert("Communication Error", "An error has occurred while trying to communicate with the REST API", "OK");
                return;
            }

            listView.ItemsSource = upcoming.results.Select(r => (Movie)r).ToList();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new MovieDetailsPage());
        }
    }
}