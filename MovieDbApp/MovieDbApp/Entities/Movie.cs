using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDbApp.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public int Position { get; set; }
        public string Title { get; set; }
        public string PosterPath { get; set; }
        public string Overview { get; set; }
        //public DateTime ReleaseDate { get; set; }
        public List<int> GenreIds { get; set; }
        public string DisplayGenre { get; set; }
        public string ReleaseDate { get; set; }
    }
}
