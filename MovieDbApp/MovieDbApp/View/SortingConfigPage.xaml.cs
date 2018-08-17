using MovieDbApp.SortingConfig;
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
	public partial class SortingConfigPage : ContentPage
	{
		public SortingConfigPage()
		{
			InitializeComponent();
            BindingContext = new SortingConfigViewModel(Navigation);
            listView.ItemTapped += ListView_ItemTapped;
		}

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((SortingConfigViewModel)BindingContext).Navigate((BaseCategory)e.Item);
        }
    }
}