using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteApp.Domain.Entities;

namespace TesteApp.Application.Interfaces
{
    public interface IProductService : IDisposable
    {
        Task Create(Product product);
        Task Update(Product product);
        Task Delete(int id);
        Task<Product> Get(int id);
        Task<IEnumerable<Product>> GetAll();

    }
}
