using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationLibrary.Types
{
    /// <summary>
    /// Clase con campos en los que se guardan los resultados a retornar en el metodo Insert()
    /// </summary
    class RespuestaInsert
    {
        private string error;
        private int resultado;

        public string Error
        {
            get { return error; }
            set { error = value; }
        }
        public int Resultado
        {
            get { return resultado; }
            set { resultado = value; }
        }
    }
}
