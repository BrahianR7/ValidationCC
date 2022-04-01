﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValidationCC.IServices;

namespace ValidationCC.Services
{
    public class ValidService: IValidService
    {
        public string Insert(string entrada)
        {
            char digito;
            bool isNumeric = false;
            string stade = "Rechazado";
            string error = "Error, el valor ingresado es nulo o string.";
            int resultado = 0;
            int num;
            try
            {
                num = int.Parse(entrada);
                isNumeric = true;
            }
            catch (Exception)
            {
                return ("Stade: " + stade + ".\nMessage error: " + error + "\nResponse: " + entrada);
                throw;
            }
            finally
            {
                if (entrada != null && isNumeric)
                {
                    for (int i = 0; i < entrada.Length; i++)
                    {
                        stade = "Aceptado";
                        error = "";
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
                        resultado += calculo;
                    }
                }
            }
            return ("Stade: " + stade + ".\nMessage error: " + error + "\nResponse: " + resultado);
        }

        public string Query()
        {
            string resultado = "inputValue: " + "\nnewInput: " ;
            return resultado;
        }

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
            else if (edad < 55)
            {
                caso = " usted debería estar descansando.";
            }
            return "Hola " + nombre + caso;
        }
    }
}
