using MovieDbApp.Entities;
using System.Collections.Generic;
using System.ComponentModel;

namespace MovieDbApp.ViewModel
{
    public class MovieDetailsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<int> genreIds;
        private string _displayGenre;

        public string Title { get; set; }
        public string PosterPath { get; set; }
        public string Overview { get; set; }
        public string ReleaseDate { get; set; }
        public string DisplayGenre
        {
            get
            {
                return _displayGenre;
            }
            set
            {
                _displayGenre = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DisplayGenre))); // Não precisa maaaaais!!!! (Eu acho...)
            }
        }

        public MovieDetailsViewModel(Movie movie)
        {
            genreIds = movie.GenreIds;
            Overview = movie.Overview;
            PosterPath = movie.PosterPath;
            ReleaseDate = movie.ReleaseDate;
            Title = movie.Title;
            DisplayGenre = movie.DisplayGenre;
        }
    }
}
