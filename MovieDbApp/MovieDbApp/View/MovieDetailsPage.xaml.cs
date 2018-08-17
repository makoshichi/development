using MovieDbApp.Entities;
using MovieDbApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovieDbApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MovieDetailsPage : ContentPage
	{
		public MovieDetailsPage (Movie movie)
		{
			InitializeComponent();
            BindingContext = new MovieDetailsViewModel(movie);
        }
    }
}