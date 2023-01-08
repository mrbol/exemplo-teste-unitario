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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
