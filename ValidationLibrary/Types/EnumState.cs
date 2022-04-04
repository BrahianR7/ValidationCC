using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationLibrary.Types
{
    class EnumState
    {
        /// <summary>
        /// Enum con dos tipos de estados para responder según la petición, utilizado en el metodo Insert() Http Post
        /// </summary>
        public enum state { Aceptado, Rechazado };
    }
}
