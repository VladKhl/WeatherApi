using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApi
{
    public static class Constants
    {
        public static string RestUrl = "https://api.openweathermap.org/data/2.5/weather?q={0}&units=metric&appid=e1d8ba646cd0a352ba9c4d209415004b&lang=ru";
        public static string RestUrl2 = "https://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&units=metric&appid=e1d8ba646cd0a352ba9c4d209415004b&lang=ru";
    }
}
