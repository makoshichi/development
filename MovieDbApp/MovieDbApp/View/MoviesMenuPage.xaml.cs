using MovieDbApp.MoviesSorting;
using MovieDbApp.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovieDbApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MoviesMenuPage : ContentPage
	{
		public MoviesMenuPage()
		{
			InitializeComponent();
            BindingContext = new MoviesMenuViewModel(Navigation);
            listView.ItemTapped += ListView_ItemTapped;
		}

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((MoviesMenuViewModel)BindingContext).Navigate((IMovieMenu)e.Item);
            listView.SelectedItem = null;
        }
    }
}