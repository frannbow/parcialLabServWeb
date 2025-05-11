using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Parcial.Aplication.DTOs;

namespace Parcial.Aplication.Services
{
    public class WeatherServices : iWeatherServices
    {
        public Task<List<WeatherDTO>> GetAllWeatherInfo()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7014");
            var result = client.GetFromJsonAsync<List<WeatherDTO>>("WeatherForecast");

            return result;
        }
        public Task<WeatherDTO> GetWeatherByCity(string city)
        {
            throw new NotImplementedException();
        }
    }
    
}
