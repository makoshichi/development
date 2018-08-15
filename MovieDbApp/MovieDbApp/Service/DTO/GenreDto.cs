using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDbApp.Service.DTO
{
    // I decided in favor of DTOs given that the JSON response from the API comes flattened as "name":value; it also allows me to get rid of snake_casing
    public class GenreDto
    {
        public List<Genre> genres;

        public class Genre
        {
            public int id { get; set; }
            public string name { get; set; }

            public static explicit operator Model.Genre(Genre genre)
            {
                return new Model.Genre
                {
                    Id = genre.id,
                    Name = genre.name
                };
            }
        }
    }
}
