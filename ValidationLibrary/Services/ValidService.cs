using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValidationLibrary.IServices;
using ValidationLibrary.Types;
using static ValidationLibrary.Types.EnumState;

namespace ValidationLibrary.Services
{
    /// <summary>
    /// Clase ValidService encargada de la logica de negocios invocada en el cotrolador
    /// </summary>
    public class ValidService: IValidService
    {
        /// <summary>
        /// Instancia a clases
        /// </summary>
        RespuestaQuery respuestaQuery = new RespuestaQuery();
        RespuestaInsert respuestaInsert = new RespuestaInsert();
        ListaTipoRespuestaQuery salida = new ListaTipoRespuestaQuery();
        state estado;

        /// <summary>
        /// Metodo ToString encargado de devolver una cadena con la respuesta a la petición realizada a Insert()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string message = ("State: " + estado + "\nMessage error: " + respuestaInsert.Error + "\nResponse: " + respuestaInsert.Resultado);
            return message;
        }

        /// <summary>
        /// Lista static en la que guardo el valor de entrada 
        /// del metodo Insert() y el valor retornado para devolver
        /// los ultimos valores agregados en la petición Get Query().
        /// </summary>
        

        /// <summary>
        /// Metodo Insert() recibe un json con un solo campo llamado input,
        /// donde va a recibir una cadena, y se debe validar si la cadena
        /// es numérica (tiene solo números)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string Insert(string input)
        {
            string respuesta;
            char digito;
            if (String.IsNullOrEmpty(input))
            {
                respuestaInsert.Resultado = 0;
                estado = state.Rechazado;
                respuestaInsert.Error = "Error, el valor ingresado es nulo o string.";
                respuesta = ToString();
                return respuesta;
            }
            try
            {
                for (int i = 0; i < input.Length; i++)
                {
                    digito = input[i];
                    int calculo = Convert.ToInt32(Convert.ToString(digito));
                    if (digito % 2 == 0)
                        calculo *= 2;
                    else
                        calculo *= 3;
                    respuestaInsert.Resultado += calculo;
                }
            }
            catch (Exception)
            {
                respuestaInsert.Resultado = 0;
                estado = state.Rechazado;
                respuestaInsert.Error = "Error, el valor ingresado es nulo o string.";
                respuesta = ToString();
                return respuesta;
                throw;
            }
            
            respuestaQuery.Input = input;
            respuestaQuery.Output = Convert.ToString(respuestaInsert.Resultado);
            salida.Salida.Add(respuestaQuery);
            //RespuestaQuery(input);
            //salida.Add(Convert.ToString(respuestaInsert.Resultado));
            respuesta = ToString();
            return respuesta;
        }

        /// <summary>
        /// Metodo Insert() devuelve lo que está en memoria
        /// en el archivo, indicando el valor recibido y el valor calculado:
        /// Ejemplo, con el campo anterior, se devuelve una lista con los campos:
        /// inputValue: 123
        /// newInput: 1
        /// </summary>
        /// <returns></returns>
        public string Query()
        {
            string resultado = "inputValue: " + salida.Salida[salida.Salida.Count -1].Input + "\nnewInput: " + salida.Salida[salida.Salida.Count - 1].Output;
            return resultado;
        }

        /// <summary>
        /// //Saludo: Método que recibe un valor json con los siguientes campos:
        /// name : Nombre de una persona
        /// age: edad de la persona
        /// Con los datos recibidos se debe devolver un mensaje según las condiciones.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="edad"></param>
        /// <returns></returns>
        public string Saludo(string nombre, int edad)
        {
            string caso = " ";
            try
            {
                switch (edad)
                {
                    case < 6:
                        caso = " usted debería estar viendo Cartoon Network.";
                        break;

                    case > 5 and < 18:
                        caso = " usted debe tener autorización de sus papás.";
                        break;

                    case > 17 and < 25:
                        caso = " usted debería estar estudiando.";
                        break;

                    case > 24 and < 56:
                        caso = " usted debería estar trabajando.";
                        break;
                    case > 55:
                        caso = " usted debería estar descansando.";
                        break;
                }
            }
            catch (Exception)
            {
                return "Error, el valor ingresado es nulo o string.";
                throw;
            }
            return "Hola " + nombre + caso;
        }
    }
}
