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
            //AVALIA SE É LANÇADA UMA EXCEÇÃO DO TIPO ArgumentException QUANDO É
            //TENTADO CRIAR UM OBJETO Email A PARTIR DE UMA STRING "valor qualquer"
        }
    }
}