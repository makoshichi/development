using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDbApp
{
    public static class Constants
    {
        //https://api.themoviedb.org/3/genre/movie/list?api_key=1f54bd990f1cdfb230adb312546d765d
        //https://api.themoviedb.org/3/movie/upcoming?api_key=1f54bd990f1cdfb230adb312546d765d&page=1
        public readonly static string BASE_URL = "https://api.themoviedb.org/3/";
        public readonly static string API_KEY = "1f54bd990f1cdfb230adb312546d765d";
        public readonly static string POSTER_BASE_PATH = "http://image.tmdb.org/t/p/w185";
    }
}
