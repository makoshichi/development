using MovieDbApp.Entities;

namespace MovieDbApp.ViewModel
{
    public class MovieDetailsViewModel
    {
        public string Title { get; set; }
        public string PosterPath { get; set; }
        public string Overview { get; set; }
        public string ReleaseDate { get; set; }
        public string DisplayGenre { get; set; }

        public MovieDetailsViewModel(Movie movie)
        {
            Overview = movie.Overview;
            PosterPath = movie.PosterPath;
            ReleaseDate = movie.ReleaseDate;
            Title = movie.Title;
            DisplayGenre = movie.DisplayGenre;
        }
    }
}
