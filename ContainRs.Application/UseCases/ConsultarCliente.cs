using ContainRs.Application.Repositories;
using ContainRs.Domain.Models;

namespace ContainRs.Application.UseCases
{
    public class ConsultarCliente
    {
        //ATRIBUTOS
        private readonly IClienteRepository repository;
        public UnidadeFederativa? Estado { get; }

        //CONSTRUTOR
        public ConsultarCliente(UnidadeFederativa? estado, IClienteRepository repository)
        {
            Estado = estado;
            this.repository = repository;
        }

        //MÉTODO QUE RETORNA UM ENUMERABLE DE CLIENTES, DADO O FILTRO/EXPRESSÃO 
        public Task<IEnumerable<Cliente>> ExecutarAsync()
        {
            if(Estado is not null)
            {
                //TODOS CLIENTES CUJO ESTADO SEJA O PASSADO NO FILTRO
                return repository.GetAsync(c => c.Estado == Estado);
            }

            //SE Estado FOR NULL, RETORNA O DEFAULT DO MÉTODO GetAsync (QUE É NULL)
            return repository.GetAsync();
        }
    }
}
