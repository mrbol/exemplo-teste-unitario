using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteApp.Application.Interfaces;
using TesteApp.Domain;
using TesteApp.Domain.Entities;

namespace TesteApp.Persistence.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p => p.Rate).HasColumnType("decimal(10, 2)");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }

        Task<int> IApplicationDbContext.SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
