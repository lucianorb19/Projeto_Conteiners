using ContainRs.Domain.Models;
using System.Linq.Expressions;

namespace ContainRs.Application.Repositories
{
    public interface IClienteRepository
    {
        //MÉTODO ABSTRATO PARA ADICIONAR CLIENTE
        Task<Cliente> AddAsync(Cliente cliente);

        //MÉTODO ABSTRATO PARA CONSULTAR CLIENTES SEGUINDO A CONDIÇÃO DA EXPRESSÃO
        //Expression<Func<Cliente, bool>>? filtro = default - RECURSO DO ENTITY
        //QUE REPRESENTA UM CONJUNTO DE CONDIÇÕES PARA SER USADA NA CONSULTA SQL
        //RETORNA NULL POR PADRÃO, CASO NÃO HAJA RESPOSTA
        Task<IEnumerable<Cliente>> GetAsync(Expression<Func<Cliente, bool>>? filtro = default);
    }
}
