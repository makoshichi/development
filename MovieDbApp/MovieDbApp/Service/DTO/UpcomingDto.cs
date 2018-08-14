using MovieDbApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDbApp.Service.DTO
{
    public class UpcomingDto
    {
        public List<Result> results { get; set; }
        public int page { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }

        public class Result
        {
            public int vote_count { get; set; }
            public int id { get; set; }
            public bool video { get; set; }
            public float vote_average { get; set; }
            public string title { get; set; }
            public float popularity { get; set; }
            public string poster_path { get; set; }
            public string original_language { get; set; }
            public string original_title { get; set; }
            public List<int> genre_ids { get; set; }
            public string backdrop_path { get; set; }
            public bool adult { get; set; }
            public string overview { get; set; }
            public string release_date { get; set; }

            public static explicit operator Movie(Result dto)
            {
                var movie = new Movie
                {
                    Id = dto.id,
                    Title = dto.title,
                    PosterPath = dto.poster_path,
                    ReleaseDate = dto.release_date,
                    GenreIds = dto.genre_ids,
                    Overview = dto.overview
                };

                return movie;
            }
        }
    }
}
