using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ValidationLibrary.IServices
{
    /// <summary>
    /// Interfaz de ValidService, servicios utilizados en el controlador
    /// </summary>
    public interface IValidService
    {
        public string Insert(string entrada);
        public string Query();
        public string Saludo(string nombre, int edad);   
    }
}
