using System;
using WeatherApi.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApi
{
    public partial class App : Application
    {
        public static ToDoManager TodoManager;
        public App()
        {
            InitializeComponent();
            TodoManager = new ToDoManager(new RestService());
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
