using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parcial.Aplication.DTOs;

namespace Parcial.Aplication.Services
{
    public interface iWeatherServices
    {
        Task<List<WeatherDTO>> GetAllWeatherInfo();
        Task<WeatherDTO> GetWeatherByCity(string city);
    }
}
