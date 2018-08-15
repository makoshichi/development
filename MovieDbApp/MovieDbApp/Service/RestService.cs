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
    public class RestService
    {
        HttpClient client;

        public RestService()
        {
            client = new HttpClient();
        }

        public async Task<UpcomingModel> GetUpcomingMovies(int page)
        {
            var result = new UpcomingModel();

            var uri = new Uri($"https://api.themoviedb.org/3/movie/upcoming?api_key=1f54bd990f1cdfb230adb312546d765d&page={page}");

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<UpcomingModel>(content);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }

            return result;
        }

        public async Task<List<Genre>> GetGenres()
        {
            var result = new GenreModel();
            var uri = new Uri($"https://api.themoviedb.org/3/genre/movie/list?api_key=1f54bd990f1cdfb230adb312546d765d");

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<GenreModel>(content);
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }

            return result.genres.Select(x => (Genre)x).ToList();
        }
    }
}
