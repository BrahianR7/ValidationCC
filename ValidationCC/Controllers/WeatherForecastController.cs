using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectUno.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            //Se invoca el metodo y el valor retornado se guarda en la variable respuesta
            var respuesta =  _validService.Insert(entrada);
            return (respuesta);
        }
        
        [Route("Saludo")]
        [HttpPost]
        public string Saludo(string nombre, int edad)
        {
            //Se invoca el metodo y el valor retornado se guarda en la variable respuesta
            var respuesta = _validService.Saludo(nombre, edad);
            return respuesta;
        }

        [Route("Query")]
        [HttpGet]
        public string Query()
        {
            //Se invoca el metodo y el valor retornado se guarda en la variable respuesta
            var respuesta = _validService.Query();
            return respuesta;
        }
    }
}
