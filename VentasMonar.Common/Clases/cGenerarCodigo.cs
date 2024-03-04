using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BarcodeLib;
namespace VentasMonar.Desktop.Clases
{
    class cGenerarCodigo
    {
        
            public const string ALPHANUMERIC_CAPS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            public const string ALPHA_CAPS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            public const string NUMERIC = "1234567890";

            Random rand = new Random();
            public string GetRandomString(int length, params char[] chars)
            {
                string s = "";
                for (int i = 0; i < length; i++)
                    s += chars[rand.Next() % chars.Length];

                return s;
            }
            
           
            
    }

}
