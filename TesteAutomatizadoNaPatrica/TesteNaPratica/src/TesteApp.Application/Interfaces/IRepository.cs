using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TesteApp.Domain.Common;
using TesteApp.Domain.Entities;

namespace TesteApp.Application.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        Task Create(TEntity entity);
        Task<TEntity> Get(int id);
        Task<List<TEntity>> GetAll();
        Task Update(TEntity entity);
        Task Delete(int id);
        Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }

    public interface IProductRepository : IRepository<Product> { 

    }
}
