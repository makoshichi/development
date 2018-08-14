using MovieDbApp.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Diagnostics;
using MovieDbApp.Data.DTO;

namespace MovieDbApp.Data
{
    public class RestService
    {
        HttpClient client;

        //public UpcomingDto Result { get; private set; }

        public RestService()
        {
            client = new HttpClient();
        }

        public async Task<UpcomingDto> GetUpcomingMovies(int page)
        {
            var result = new UpcomingDto();

            var uri = new Uri($"https://api.themoviedb.org/3/movie/upcoming?api_key=1f54bd990f1cdfb230adb312546d765d&page={page}");

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<UpcomingDto>(content);
                }
            }
            catch (Exception e)
            {
                // Delegating exception treatment to the View
                Debug.WriteLine(e.Message);
                return null;
            }

            return result;
        }
    }
}
