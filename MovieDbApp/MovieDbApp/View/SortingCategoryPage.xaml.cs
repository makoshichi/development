using MovieDbApp.Category;
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
	public partial class SortingCategoryPage : ContentPage
	{
		public SortingCategoryPage()
		{
			InitializeComponent();
            BindingContext = new SortingCategoryViewModel(Navigation);
            listView.ItemTapped += ListView_ItemTapped;
		}

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((SortingCategoryViewModel)BindingContext).Route((BaseCategory)e.Item);
        }
    }
}