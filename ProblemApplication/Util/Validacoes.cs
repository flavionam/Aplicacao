using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Util
{
    public class Validacoes
    {
        private const string emailExpression = @"^\w+([\-\+\.\']\w+)*@\w+([\-\.]\w+)*\.\w+([\-\.]\w+)*$";

        public static string validarEmail(string email)
        {
            Regex regularExpression = null;

            // nao parei a rotina caso o email seja inválido
            string textoRetorno = "E-mail inválido";

            try
            {
                regularExpression = new Regex(emailExpression);

                if (regularExpression.IsMatch(email.Trim()))
                    textoRetorno = email;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return textoRetorno;

        }


        public static DateTime validarData(string data)
        {
            // nao parei a rotina caso a data seja inválida
            DateTime dataRetorno = DateTime.MinValue;

            try
            {
                string dataMascara = data.Insert(4, "/").Insert(7, "/");
                dataRetorno = Convert.ToDateTime(dataMascara);

            }
            catch (Exception)
            { }

            return dataRetorno;

        }
    }
}
