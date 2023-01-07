using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteApp.Domain.Interfaces;
using TesteApp.Domain.Models;
using TesteApp.Domain.Models.Validations;

namespace TesteApp.Application
{
    public class ProdutoService : BaseService, IClienteService
    {
        private readonly IRepository<Cliente> _clienteRepository;

        public ProdutoService(IRepository<Cliente> clienteRepository,
                              INotificador notificador) : base(notificador)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task Adicionar(Cliente cliente)
        {
            if (!ExecutarValidacao(new ClienteValidation(), cliente)) return;

            await _clienteRepository.Adicionar(cliente);
        }

        public async Task Atualizar(Cliente cliente)
        {
            if (!ExecutarValidacao(new ClienteValidation(), cliente)) return;

            await _clienteRepository.Atualizar(cliente);
        }

        public void Dispose()
        {
            _clienteRepository?.Dispose();
        }

        public async Task<Cliente> ObterPorId(Guid id)
        {
           return await _clienteRepository.ObterPorId(id);
        }

        public async Task<List<Cliente>> ObterTodos()
        {
            return await _clienteRepository.ObterTodos();
        }

        public async Task Remover(Guid id)
        {
            await _clienteRepository.Remover(id);
        }
    }
}
