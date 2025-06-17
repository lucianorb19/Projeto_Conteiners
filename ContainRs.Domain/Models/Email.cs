using System.Text.RegularExpressions;

namespace ContainRs.Domain.Models
{
    public class Email
    {
        //PROPRIEDADES
        //Value -  que é a string para o e-mail
        public string Value { get;}

        //EXPRESSÃO REGULAR PARA LÓGICA DE VALIDAÇÃO DO E-MAIL
        private static readonly Regex EmailRegex = new Regex(
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);


        //CONSTRUTOR QUE JÁ FAZ A VALIDAÇÃO DO E-MAIL
        public Email(string value)
        {
            if (!EmailRegex.IsMatch(value))
            {
                throw new ArgumentException("E-mail inválido.");
            }
            Value = value;
        }
    }
}
