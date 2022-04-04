using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationLibrary.Types
{
    /// <summary>
    /// Clase con campos con los que creo una list de este tipo en los 
    /// que se guardan los resultados a retornar en el metodo Query()
    /// </summary
    public class RespuestaQuery
    {
        private string input;
        private string output;

        public string Input
        {
            get { return input; }
            set { input = value; }
        }
        public string Output
        {
            get { return output; }
            set { output = value; }
        }
    }
}
