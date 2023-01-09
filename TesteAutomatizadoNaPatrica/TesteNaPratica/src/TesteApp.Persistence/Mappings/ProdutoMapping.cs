using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TesteApp.Persistence.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Description)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            builder.Property(p => p.Barcode)
                .IsRequired()
                .HasColumnType("varchar(255)");
            builder.Property(p => p.Rate)
            .IsRequired()
            .HasColumnType("decimal(10,2)");

            builder.ToTable("Products");
        }
    }
}
