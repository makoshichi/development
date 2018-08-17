using MovieDbApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDbApp.Service
{
    public class GenreModel : IModel
    {
        public List<GenreResult> genres;
    }
    
    public class GenreResult
    {
        public int id { get; set; }
        public string name { get; set; }

        public static explicit operator Genre(GenreResult genre)
        {
            return new Genre
            {
                Id = genre.id,
                Name = genre.name
            };
        }
    }
}
