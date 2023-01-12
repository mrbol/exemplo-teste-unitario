using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TesteApp.Application.Interfaces;
using TesteApp.Domain;
using TesteApp.Domain.Entities;
using TesteApp.Persistence.Mappings;

namespace TesteApp.Persistence.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ProdutoMapping().Configure(modelBuilder.Entity<Product>());
            
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }

        Task<int> IApplicationDbContext.SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
