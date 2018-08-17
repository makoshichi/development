using MovieDbApp.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Linq;

namespace MovieDbApp.Service
{
    // Developer note: I took a look at the whole API trying to find ideas on how to make the REST service more scalable but it probably would amount to much more work than it's worth right now,
    // so I decided in favor of creating a very minimal service fit for simple constructor injection
    public class RestService : IRestService
    {
        private HttpClient client;

        public RestService()
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
