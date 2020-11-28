using FichaAcademia.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FichaAcademia.AcessoDados.Mapeamentos
{
    public class AdministradorMap : IEntityTypeConfiguration<Administrador>
    {
        public void Configure(EntityTypeBuilder<Administrador> builder)
        {
            builder.ToTable("Administradores");

            builder.HasKey(a => a.AdministradoresId);

            builder.Property(a => a.Nome).IsRequired();
            builder.Property(a => a.Email).IsRequired();
            builder.Property(a => a.Senha).IsRequired();
        }
    }
}
