using MovieDbApp.Navigation;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MovieDbApp.View
{
    public partial class MasterPage : ContentPage
    {
        public MasterPage()
        {
            InitializeComponent();
            var masterPageItems = new List<MasterPageItem>();
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Movies",
                IconSource = "contacts.png", // File not found
                TargetType = typeof(MoviesSortingPage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "TV",
                IconSource = "todo.png", // File not found
                TargetType = typeof(PageNotFound)
            });

            ListView.ItemsSource = masterPageItems;
        }
    }
}
