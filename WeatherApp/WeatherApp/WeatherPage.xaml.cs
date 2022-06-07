using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherPage : ContentPage
    {
        public WeatherPage()
        {
            InitializeComponent();
        }

        private async void WeatherButton_Clicked(object sender, EventArgs e)
        {
            WeatherDetails details = await GetRemoteWeatherDeatails();

            BindingContext = details;
        }

        private async Task<WeatherDetails> GetRemoteWeatherDeatails()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");


            string response = await client.GetStringAsync("https://openweathermap.org/");

            WeatherDetails details = JsonConvert.DeserializeObject<WeatherDetails>(response);

            return details;
        }
    }

}