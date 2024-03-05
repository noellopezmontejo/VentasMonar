using System;
using System.Collections.Generic;
using System.Text;

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace VentasMonar.Common.Clases
{
    public class Encriptar
    {
        private string patron_busqueda = "ABCDEFGHIJKLMNÑOPQRSTVWXYZabcdefghijklmnñopqrstvwxyz1234567890";
        private string Patron_encripta = "1234567890ABCDEFGHIJKLMNÑOPQRSTVWXYZabcdefghijklmnñopqrstvwxyz";

        public string EncriptarCadena(string cadena)
        {
            int idx;   
            string result="";
  
           for(idx=0; idx<=cadena.Length -1; idx++)
           {
               result += EncriptarCaracter(cadena.Substring(idx, 1), cadena.Length, idx);
           }
            
           return result;

        }
        public string EncriptarCaracter(string caracter, int variable, int a_indice)
        {
            string  caracterEncriptado=""; int indice;

            if (patron_busqueda.IndexOf(caracter) != -1)
            {
                indice = (patron_busqueda.IndexOf(caracter) + variable + a_indice) % patron_busqueda.Length;
                return Patron_encripta.Substring(indice, 1);
            }

            return caracter;

        }

        public string DesEncriptarCadena(string cadena)
        {
           int idx;string result="";

           for (idx = 0; idx <= cadena.Length - 1; idx++)
           {
               result += DesEncriptarCaracter(cadena.Substring(idx, 1), cadena.Length, idx);
           }

           return result;


        }
        public string DesEncriptarCaracter(string caracter, int variable, int a_indice)
        {
            int indice;

            if (Patron_encripta.IndexOf(caracter) != -1)
            {
                if ((Patron_encripta.IndexOf(caracter) - variable - a_indice) > 0)
                {
                    indice = (Patron_encripta.IndexOf(caracter) - variable - a_indice) % Patron_encripta.Length;
                }
                else
                {
                    //La línea está cortada por falta de espacio
                    indice = (patron_busqueda.Length) + ((Patron_encripta.IndexOf(caracter) - variable - a_indice) % Patron_encripta.Length);

                }
                indice = indice % Patron_encripta.Length;
                return patron_busqueda.Substring(indice, 1);
            }
            else
            {
                return caracter;
            }

        }


    }
}
