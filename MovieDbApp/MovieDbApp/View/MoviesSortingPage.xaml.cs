using MovieDbApp.MoviesSorting;
using MovieDbApp.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovieDbApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MoviesSortingPage : ContentPage
	{
		public MoviesSortingPage()
		{
			InitializeComponent();
            BindingContext = new MovieSortingViewModel(Navigation);
            listView.ItemTapped += ListView_ItemTapped;
		}

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((MovieSortingViewModel)BindingContext).Navigate((ISortingCategory)e.Item);
            listView.SelectedItem = null;
        }
    }
}