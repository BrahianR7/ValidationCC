using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectUno.IServices;
using static ProjectUno.Services.RespuestaInsert;

namespace ProjectUno.Services
{
    //Clase con campos a retornar en el metodo Insert()
    public class RespuestaInsert
    {
        public enum state { Aceptado, Rechazado };
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
    public class ValidService: IValidService
    {
        //Instacia clase respuestaInsert
        RespuestaInsert respuestaInsert = new RespuestaInsert();

        state estado;

        public override string ToString()
        {
            string message = ("State: " + estado + "\nMessage error: " + respuestaInsert.Error + "\nResponse: " + respuestaInsert.Resultado);
            return message;
        }
        //Lista en la que guardo el valor de entrada del metodo Insert() y el valor retornado.
        public static List<string> salida = new List<string>();

        //Metodo Insert() recibe un json con un solo campo llamado input,
        //donde va a recibir una cadena, y se debe validar si la cadena
        //es numérica (tiene solo números)
        public string Insert(string entrada)
        {
            string respuesta;
            char digito;
            bool isNumeric = false;
            try
            {
                for (int i = 0; i < entrada.Length; i++)
                {
                    digito = entrada[i];
                    int calculo = Convert.ToInt32(Convert.ToString(digito));
                }
                isNumeric = true;
            }
            catch (Exception)
            {
                estado = state.Rechazado;
                respuestaInsert.Error = "Error, el valor ingresado es nulo o string.";
                respuesta = ToString();
                return respuesta;
                throw;
            }
            if (String.IsNullOrEmpty(entrada) || isNumeric == false)
            {
                estado = state.Rechazado;
                respuestaInsert.Error = "Error, el valor ingresado es nulo o string.";
                respuesta = ToString();
                return respuesta;
            }
            else
            {
                for (int i = 0; i < entrada.Length; i++)
                {
                    
                    digito = entrada[i];
                    int calculo = Convert.ToInt32(Convert.ToString(digito));
                    if (digito % 2 == 0)
                    {
                        calculo *= 2;
                    }
                    else
                    {
                        calculo *= 3;
                    }
                    estado = state.Aceptado;
                    respuestaInsert.Error = "";
                    respuestaInsert.Resultado += calculo;
                    salida.Add(entrada);
                    salida.Add(Convert.ToString(respuestaInsert.Resultado));
                }
                respuesta = ToString();
                return respuesta;
            }
        }

        //Metodo Insert() devuelve lo que está en memoria
        //o en el archivo, indicando el valor recibido y el valor calculado:
        //- Ejemplo, con el campo anterior, se devuelve una lista con los campos:
        //o inputValue: 123
        //o newInput: 1
        public string Query()
        {
            string newInput = salida[salida.Count -1];
            string inputValue = salida[salida.Count -2];
            string resultado = "inputValue: " + inputValue + "\nnewInput: " + newInput;
            return resultado;
        }

        //Saludo: Método que recibe un valor json con los siguientes campos:
        //o name : Nombre de una persona
        //o age: edad de la persona
        //- Con los datos recibidos se debe devolver un mensaje según las condiciones
        public string Saludo(string nombre, int edad)
        {
            string caso = " ";
            if (edad < 6)
            {
                caso = " usted debería estar viendo Cartoon Network.";
            }
            else if (edad > 5 && edad < 18)
            {
                caso = " usted debe tener autorización de sus papás.";
            }
            else if (edad > 17 && edad < 25)
            {
                caso = " usted debería estar estudiando.";
            }
            else if (edad > 24 && edad < 56)
            {
                caso = " usted debería estar trabajando.";
            }
            else if (edad > 55)
            {
                caso = " usted debería estar descansando.";
            }
            return "Hola " + nombre + caso;
        }
    }
}
