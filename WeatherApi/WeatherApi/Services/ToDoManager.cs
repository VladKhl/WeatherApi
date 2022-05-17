using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApi.Model;

namespace WeatherApi.Services
{
    public class ToDoManager
    {
        IRestService service;

        public ToDoManager(IRestService restService)
        {
            service = restService;
        }
        public Task<Rootobject> GetTodoItemModels(string cityName)
        {
            return service.GetTodoItemAsync(cityName);
        }
    }
}
