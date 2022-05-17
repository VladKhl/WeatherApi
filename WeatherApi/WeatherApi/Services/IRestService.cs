using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApi.Model;

namespace WeatherApi.Services
{
    public interface IRestService
    {
        Task<Rootobject> GetTodoItemAsync(string cityName);
    }
}
