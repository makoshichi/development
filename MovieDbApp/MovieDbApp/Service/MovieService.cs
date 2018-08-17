using MovieDbApp.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Linq;
using MovieDbApp.Entities;

namespace MovieDbApp.Service
{
    public class MovieService : IRestService
    {
        private HttpClient client;

        public MovieService()
        {
            client = new HttpClient();
        }

        public async Task<UpcomingModel> GetUpcomingMovies(int page)
        {
            var route = "/movie/upcoming";
            var uri = new Uri($"{Constants.BASE_URL}{route}?api_key={Constants.API_KEY}&page={page}");
            var result = await GetData<UpcomingModel>(uri);

            return result;
        }

        public async Task<List<Genre>> GetGenres()
        {
            var route = "/genre/movie/list";
            var uri = new Uri($"{Constants.BASE_URL}{route}?api_key={Constants.API_KEY}");
            var result = await GetData<GenreModel>(uri);

            return result.genres.Select(x => (Genre)x).ToList();
        }

        private async Task<T> GetData<T>(Uri uri) where T : IJsonModel // Marker interface usage
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
    }
}
