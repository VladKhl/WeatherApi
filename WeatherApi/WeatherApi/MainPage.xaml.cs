using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApi.Model;
using Xamarin.Forms;

namespace WeatherApi
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void CitiesNamesSearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            try
            {
                Rootobject a = await App.TodoManager.GetTodoItemModels(CitiesNamesSearchBar.Text);
                BindingContext = a;
                TempLbl.Text = a.main.temp.ToString() + " ℃  ";
                FeelsLikeLbl.Text = a.main.feels_like.ToString() + " ℃  ";
                PressureLbl.Text = a.main.pressure.ToString() + " Н/м2";
                HumidityLbl.Text = a.main.humidity.ToString() + " г/м³";
                WindLbl.Text = a.wind.speed.ToString() + " м/с";

            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", $"Введите название города\n{ex.Message}", "Ok");
            }
        }
    }
}
