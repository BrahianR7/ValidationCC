using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValidationCC.IServices;

namespace ValidationCC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IValidService _validService;
        public WeatherForecastController(IValidService validService)
        {
            _validService = validService;
        }

        [Route("Insert")]
        [HttpPost]
        public string Insert(string entrada)
        {
            var respuesta =  _validService.Insert(entrada);
            return (respuesta);
        }


        [Route("Saludo")]
        [HttpPost]
        public string Saludo(string nombre, int edad)
        {
            var respuesta = _validService.Saludo(nombre, edad);
            return respuesta;
        }

        [HttpGet]
        public string Query()
        {
            var respuesta = _validService.Query();
            return respuesta;
        }
    }
}
