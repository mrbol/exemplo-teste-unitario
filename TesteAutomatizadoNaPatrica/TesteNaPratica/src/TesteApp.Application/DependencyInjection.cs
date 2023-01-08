using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TesteApp.Application.Interfaces;
using TesteApp.Domain.Entities;

namespace TesteApp.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            //services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IProductService, ProductService>();
        }
    }
}