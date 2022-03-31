using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ValidationCC.IServices
{
    public interface IValidService
    {
        public string Insert(string entrada);

        public string Saludo(string nombre, int edad);
    }
}
