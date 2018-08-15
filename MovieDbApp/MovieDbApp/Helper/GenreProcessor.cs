using MovieDbApp.Model;
using MovieDbApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDbApp.Helper
{
    public class GenreProcessor
    {
        public static string ConvertToDisplayGenre(List<int> genreIds, List<Genre> allGenres)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < genreIds.Count; i++)
            {
                var genreName = allGenres.First(x => x.Id == genreIds[i]).Name;

                if (i == genreIds.Count - 1)
                    sb.Append(genreName);
                else
                    sb.Append($"{genreName}, ");

            }

            return sb.ToString();
        }
    }
}
