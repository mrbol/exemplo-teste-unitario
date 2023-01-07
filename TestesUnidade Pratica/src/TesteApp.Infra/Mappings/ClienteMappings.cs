using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteApp.Domain.Models;

namespace TesteApp.Infra.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente> {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.DataNascimento)
                 .IsRequired()
                 .HasColumnType("datetime");
            builder.Property(p => p.Logradouro)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Numero)
                 .IsRequired()
                 .HasColumnType("varchar(20)");

            builder.Property(p => p.Bairro)
                 .IsRequired()
                 .HasColumnType("varchar(50)");
            builder.Property(p => p.Cidade)
                 .IsRequired()
                 .HasColumnType("varchar(50)");
            builder.Property(p => p.Estado)
                 .IsRequired()
                 .HasColumnType("varchar(50)");
            builder.Property(p => p.Cep)
                 .IsRequired()
                 .HasColumnType("varchar(10)");


            builder.ToTable("Clientes");
        }
    }
}
