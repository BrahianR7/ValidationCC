using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationLibrary.Types
{
    class ListaTipoRespuestaQuery
    {
        static List<RespuestaQuery> salida = new List<RespuestaQuery>();
        public List<RespuestaQuery> Salida
        {
            get { return salida; }
            set { salida = value; }
        }
    }
}
