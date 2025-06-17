//using ContainRs.WebApp.Models;
using ContainRs.Domain.Models;

using System.Reflection;

namespace ContainRs.Testes
{
    public class EmailCtor
    {
        [Fact]
        public void Deve_Lancar_ArgumentException_Quando_Valor_Invalido()
        {
            // arrange
            string emailInvalido = "valor qualquer";

            // act & assert
            Assert.Throws<ArgumentException>(() => new Email(emailInvalido));
            //AVALIA SE � LAN�ADA UMA EXCE��O DO TIPO ArgumentException QUANDO �
            //TENTADO CRIAR UM OBJETO Email A PARTIR DE UMA STRING "valor qualquer"
        }
    }
}