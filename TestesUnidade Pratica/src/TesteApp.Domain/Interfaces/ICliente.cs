using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteApp.Domain.Models;

namespace TesteApp.Domain.Interfaces
{
    public interface IClienteService : IDisposable
    {
        Task Adicionar(Cliente cliente);
        Task Atualizar(Cliente cliente);
        Task<Cliente> ObterPorId(Guid id);
        Task<List<Cliente>> ObterTodos();
        Task Remover(Guid id);
    }
}
