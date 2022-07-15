using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkoBey.EzanVakti.Methods
{
    public static class KarakterDuzelt
    {
        public static string Degistir(string str)
        {

            str = str.Replace("&#39;", "'");
            str = str.Replace("&#199;", "Ç");
            str = str.Replace("&#214;", "Ö");
            str = str.Replace("&#220;", "Ü");
            str = str.Replace("&#226;", "â");
            str = str.Replace("&#231;", "ç");
            str = str.Replace("&#234;", "ê");
            str = str.Replace("&#238;", "î");
            str = str.Replace("&#246;", "ö");
            str = str.Replace("&#251;", "û");
            str = str.Replace("&#252;", "ü");
            str = str.Replace("&#2876;", "Ğ");
            str = str.Replace("&#287;", "ğ");
            str = str.Replace("&#304;", "I");
            str = str.Replace("&#305;", "ı");
            str = str.Replace("&#350;", "Ş");
            str = str.Replace("&#351;", "ş");
            str = str.Replace("&quot;", "\"");

            return str;
        }


    }
}
