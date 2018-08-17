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
	public partial class MovieFiltersPage : ContentPage
	{
		public MovieFiltersPage()
		{
			InitializeComponent();
            listView.ItemsSource = new List<string>() { "Upcoming" };
            listView.ItemTapped += ListView_ItemTapped;
		}

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new UpcomingMoviesPage());
        }
    }
}