using MovieDbApp.Data;
using System.Collections.Generic;

namespace MovieDbApp.Data
{
    public class GenreResponse
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
