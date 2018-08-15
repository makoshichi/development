using MovieDbApp.Model;
using MovieDbApp.ViewModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovieDbApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MovieDetailsPage : ContentPage
	{
        private MovieDetailsViewModel viewModel;

		public MovieDetailsPage (Movie movie)
		{
			InitializeComponent();
            viewModel = new MovieDetailsViewModel(movie);
            BindingContext = viewModel;
        }

        protected async override void OnAppearing()
        {
            await Task.Run(() => viewModel.SetDisplayGenre());
            base.OnAppearing();
        }
    }
}