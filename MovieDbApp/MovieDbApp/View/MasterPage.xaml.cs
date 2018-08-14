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
                TargetType = typeof(MovieFiltersPage)
            });
            //masterPageItems.Add(new MasterPageItem
            //{
            //    Title = "TV",
            //    IconSource = "todo.png",
            //    TargetType = typeof(TodoListPage)
            //});
            //masterPageItems.Add(new MasterPageItem
            //{
            //    Title = "About",
            //    IconSource = "reminders.png",
            //    TargetType = typeof(ReminderPage)
            //});

            ListView.ItemsSource = masterPageItems;
        }
    }
}
