using MovieDbApp.MoviesSorting;
using MovieDbApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            BindingContext = new ViewModel.MoviesSortingPage(Navigation);
            listView.ItemTapped += ListView_ItemTapped;
		}

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ViewModel.MoviesSortingPage)BindingContext).Navigate((BaseCategory)e.Item);
        }
    }
}