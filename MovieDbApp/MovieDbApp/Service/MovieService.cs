using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Linq;
using MovieDbApp.Data;

namespace MovieDbApp.Service
{
    public class MovieService : IRestService
    {
        private HttpClient client;

        public MovieService()
        {
            client = new HttpClient();
        }

        #region Get Movies
        public async Task<MovieResponse> GetUpcomingMovies(int page)
        {
            var route = "/movie/upcoming";
            return await GetFromUri<MovieResponse>(page, route);
        }

        public async Task<MovieResponse> GetTopRatedMovies(int page)
        {
            var route = "/movie/top_rated";
            return await GetFromUri<MovieResponse>(page, route);
        }

        public async Task<MovieResponse> GetPopularMovies(int page)
        {
            var route = "/movie/popular";
            return await GetFromUri<MovieResponse>(page, route);
        }
        #endregion

        public async Task<List<Genre>> GetGenres()
        {
            var route = "/genre/movie/list";
            var uri = new Uri($"{Constants.BASE_URL}{route}?api_key={Constants.API_KEY}");
            var result = await GetData<GenreResponse>(uri);

            return result.genres.Select(x => (Genre)x).ToList();
        }

        #region Private Methods
        private async Task<T> GetFromUri<T>(int page, string route)
        {
            var uri = new Uri($"{Constants.BASE_URL}{route}?api_key={Constants.API_KEY}&page={page}");
            var result = await GetData<T>(uri);

            return result;
        }

        private async Task<T> GetData<T>(Uri uri)
        {
            var result = Activator.CreateInstance<T>();
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<T>(content);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return default(T);
            }

            return result;
        }


        #endregion
    }
}
