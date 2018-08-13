using System;
using Xamarin.Forms;

namespace MovieDbApp.View
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            //Master = new MasterPage();

            masterPage.ListView.ItemSelected += OnItemSelected;
            Detail = new NavigationPage(new MovieFiltersPage()); // Change here to define the first page; this page won't be on the menu, maybe not even part of navigation
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                masterPage.ListView.SelectedItem = null;
                IsPresented = false; // why?
            }
        }
    }
}
