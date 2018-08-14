using MovieDbApp.Model;
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
	public partial class MovieDetailsPage : ContentPage
	{
		public MovieDetailsPage (Movie movie)
		{
			InitializeComponent();

            var pageModel = new MovieDetailsPageModel()
            {
                GenreIds = movie.GenreIds,
                Overview = movie.Overview,
                PosterPath = movie.PosterPath,
                ReleaseDate = movie.ReleaseDate,
                Title = movie.Title
            };

            BindingContext = pageModel;
		}
	}
}