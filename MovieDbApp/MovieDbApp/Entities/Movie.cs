using System.Collections.Generic;
using System.Linq;
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
        public List<int> GenreIds { get; set; }
        public string DisplayGenre { get; set; }
        public string ReleaseDate { get; set; }

        public string ConvertToDisplayGenre(List<Genre> allGenres)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < GenreIds.Count; i++)
            {
                var genreName = allGenres.First(x => x.Id == GenreIds[i]).Name;

                if (i == GenreIds.Count - 1)
                    sb.Append(genreName);
                else
                    sb.Append($"{genreName}, ");

            }

            return sb.ToString();
        }
    }
}
