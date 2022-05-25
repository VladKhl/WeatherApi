using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeatherApi.Model;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace WeatherApi
{
    public partial class MainPage : ContentPage
    {
        CancellationTokenSource cts;
        public MainPage()
        {
            InitializeComponent();
            var res = GetCurLocation();
        }
        async Task<Location> GetCurLocation()
        {
            var requset = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(1));
            cts = new CancellationTokenSource();
            var location = await Geolocation.GetLocationAsync(requset, cts.Token);
            if (location != null)
            {
                MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(location.Latitude, location.Longitude), Distance.FromMiles(1)));
                try
                {
                    Rootobject a = await App.TodoManager.GetLocItemAsync(location.Latitude.ToString(), location.Longitude.ToString());
                    TempLbl.Text = a.main.temp.ToString() + " ℃  ";
                    FeelsLikeLbl.Text = a.main.feels_like.ToString() + " ℃  ";
                    PressureLbl.Text = a.main.pressure.ToString() + " Н/м²";
                    HumidityLbl.Text = a.main.humidity.ToString() + " г/м³";
                    desc.Text = a.weather[0].description.Substring(0, 1).ToUpper() + a.weather[0].description.Substring(1);
                    descic.Source = new UriImageSource
                    {
                        CachingEnabled = false,
                        Uri = new Uri($"http://openweathermap.org/img/wn/{a.weather[0].icon}.png"),
                    };
                    WindLbl.Text = a.wind.speed.ToString() + " м/с";
                    Pin pin = new Pin
                    {
                        Label = a.name,
                        Address = $"{a.main.temp} ℃  ",
                        Type = PinType.Place,
                        Position = (new Position(location.Latitude, location.Longitude))
                    };
                    MyMap.Pins.Add(pin);
                }
                catch
                {
                    await DisplayAlert("", "Ошибка", "Ok");
                }
            }
            return location;
        }
        private async void CitiesNamesSearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            try
            {
                Rootobject a = await App.TodoManager.GetTodoItemModels(CitiesNamesSearchBar.Text);
                TempLbl.Text = a.main.temp.ToString() + " ℃  ";
                FeelsLikeLbl.Text = a.main.feels_like.ToString() + " ℃  ";
                PressureLbl.Text = a.main.pressure.ToString() + " Н/м²";
                HumidityLbl.Text = a.main.humidity.ToString() + " г/м³";
                desc.Text = a.weather[0].description.Substring(0,1).ToUpper()+ a.weather[0].description.Substring(1);
                descic.Source = new UriImageSource
                {
                    CachingEnabled = false,
                    Uri = new Uri($"http://openweathermap.org/img/wn/{a.weather[0].icon}.png"),
                };
                WindLbl.Text = a.wind.speed.ToString() + " м/с";
                MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(a.coord.lat, a.coord.lon),
                                                         Distance.FromMiles(1)));
                Pin pin = new Pin
                {
                    Label = CitiesNamesSearchBar.Text,
                    Address = a.main.temp.ToString() + " ℃  ",
                    Type = PinType.Place,
                    Position = (new Position(a.coord.lat, a.coord.lon))
                };
                MyMap.Pins.Add(pin);

            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", $"Введите название города\n{ex.Message}", "Ok");
            }
        }
    }
}
