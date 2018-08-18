using MovieDbApp.Entities;
using System;
using System.Collections.Generic;

namespace MovieDbApp.Model
{
    public class UpcomingModel : IJsonModel
    {
        public List<UpcomingResult> results { get; set; }
        public int page { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
    }

    public class UpcomingResult
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

        public static explicit operator Movie(UpcomingResult upcoming)
        {
            var movie = new Movie
            {
                Id = upcoming.id,
                Title = upcoming.title,
                PosterPath = $"{Constants.POSTER_BASE_PATH}{upcoming.poster_path}",
                //ReleaseDate = DateTime.Parse(upcoming.release_date),
                ReleaseDate = DateTime.Parse(upcoming.release_date).ToString("MMM d, yyyy"),
                GenreIds = upcoming.genre_ids,
                Overview = upcoming.overview
            };

            return movie;
        }
    }
}
