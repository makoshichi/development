using MovieDbApp.Model;
using MovieDbApp.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DisplayGenre)));
            }
        }

        public MovieDetailsViewModel(Movie movie)
        {
            genreIds = movie.GenreIds;
            Overview = movie.Overview;
            PosterPath = movie.PosterPath;
            ReleaseDate = movie.ReleaseDate;
            Title = movie.Title;
        }

        public async void SetDisplayGenre()
        {
            var allGenres = await new RestService().GetGenres();
            var sb = new StringBuilder();

            for (int i = 0; i < genreIds.Count; i++)
            {
                var displayGenre = allGenres.First(x => x.Id == genreIds[i]).Name;

                if (i == genreIds.Count - 1)
                    sb.Append(displayGenre);
                else
                    sb.Append($"{displayGenre}, ");

            }

            DisplayGenre = sb.ToString();
        }
    }
}
