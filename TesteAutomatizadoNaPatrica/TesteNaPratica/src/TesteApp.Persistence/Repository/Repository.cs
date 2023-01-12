using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TesteApp.Persistence.Context;
using TesteApp.Application.Interfaces;
using TesteApp.Domain;
using TesteApp.Domain.Entities;
using TesteApp.Domain.Common;

namespace TesteApp.Persistence.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        protected readonly ApplicationDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(ApplicationDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> Get(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<int> Create(TEntity entity)
        {
            DbSet.Add(entity);
            return await SaveChanges();
        }

        public virtual async Task<int> Update(TEntity entity)
        {
            DbSet.Update(entity);
            return await SaveChanges();
        }

        public virtual async Task<int> Delete(int id)
        {
            DbSet.Remove(new TEntity { Id = id });
            return await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
