using PCLStorage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MovieDbApp.Service.Interfaces
{
    public class AsyncImageService
    {
        private bool isLoading;

        public async Task<ImageSource> LoadImage(string imageUrl, ImageSource target)
        {
            Stream stream;
            ImageSource imageSource = null;
            if (!isLoading)
            {
                isLoading = true;
                if (!string.IsNullOrEmpty(imageUrl))
                {
                    HttpClient client = new HttpClient();
                    var uri = new Uri(imageUrl);
                    stream = await client.GetStreamAsync(uri);
                    imageSource = ImageSource.FromStream(() => stream);
                }
            }
            isLoading = false;

            return imageSource;
        }
    }
}

