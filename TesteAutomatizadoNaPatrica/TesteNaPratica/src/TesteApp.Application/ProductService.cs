using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteApp.Application.Interfaces;
using TesteApp.Domain.Entities;

namespace TesteApp.Application
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(Product product)
        {
            await _repository.Create(product);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
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

        public async Task Update(Product product)
        {
            await _repository.Update(product);
        }
    }


}
