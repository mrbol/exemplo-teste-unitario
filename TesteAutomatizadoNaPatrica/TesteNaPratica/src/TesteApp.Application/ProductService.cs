using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteApp.Application.Interfaces;
using TesteApp.Domain.Validation;
using TesteApp.Domain.Entities;

namespace TesteApp.Application
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IValidatoService _validatoService;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
            _validatoService = new ValidatoService();
        }

        public async Task<Notifier> Create(Product product)
        {
            var errorNotification = _validatoService.RunValidation(new ProductValidation(), product);
            if (errorNotification.Exists())
            {
                return errorNotification;
            }
            var returnSearch = await _repository.Search(p => p.Name == product.Name);
            if (returnSearch.Any())
            {
                errorNotification.Add(new ItemNotification() { Name="Produto", Description="Já existe um produto registrado com nome informado."});
                return errorNotification;
            }
            await _repository.Create(product);
            return errorNotification;
        }

        public async Task<Notifier> Update(int id, Product product)
        {
            Notifier errorNotification = new Notifier();
            if (id != product.Id)
            {
                errorNotification.Add(new ItemNotification() { Name = "Id", Description = "Verifique os dados informados." });
                return errorNotification;
            }
            var existProduct = await _repository.Get(id);
            if (existProduct.Id == 0)
            {
                errorNotification.Add(new ItemNotification() { Name="Produto",Description="Produto não encontrado"});
                return errorNotification;
            }
            errorNotification = _validatoService.RunValidation(new ProductValidation(), product);
            if (errorNotification.Exists())
            {
                return errorNotification;
            }
            await _repository.Update(product);
            return errorNotification;
        }

        public async Task<bool> Delete(int id)
        {
            var existProduct = await _repository.Get(id);
            if (existProduct.Id == 0)
            {
                return false;
            }
            int result = await _repository.Delete(id);
            return (result > 0) ? true : false;
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }

        public async Task<Product> Get(int id)
        {
            return await _repository.Get(id);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}
