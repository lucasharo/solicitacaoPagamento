using Entidades;
using Microsoft.Extensions.Configuration;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Negocio
{
    public static class Util
    {
        public static CultureInfo culture = new CultureInfo("pt-BR");
        public static IConfigurationRoot Configuration;

        public static bool ValidaCampo(object campo)
        {
            bool fgOk = true;

            if(campo == null)
            {
                fgOk = false;
            } else if(campo.GetType() == typeof(string) && string.IsNullOrEmpty(campo.ToString()))
            {
                fgOk = false;
            }

            return fgOk;
        }

        public static string SomenteNumero(string valor)
        {
            string resultado = string.Empty;

            Regex regexObj = new Regex(@"[^\d]");

            resultado = regexObj.Replace(valor, "");

            return resultado;
        }

        public static string FormatarCNPJ(string cnpj)
        {
            return Convert.ToUInt64(SomenteNumero(cnpj)).ToString(@"00\.000\.000\/0000\-00");
        }
    }
}
