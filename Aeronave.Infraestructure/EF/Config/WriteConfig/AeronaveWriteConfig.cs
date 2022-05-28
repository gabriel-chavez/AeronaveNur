using Aeronave.Domain.Model.Aeronaves;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeronave.Infraestructure.EF.Config.WriteConfig
{
    public class AeronaveWriteConfig : IEntityTypeConfiguration<Aeronave.Domain.Model.Aeronaves.Aeronave>, IEntityTypeConfiguration<Mantenimiento>
    {
       
        public void Configure(EntityTypeBuilder<Domain.Model.Aeronaves.Aeronave> builder)
        {
            builder.ToTable("Aeronave");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Estado)
                .HasColumnName("estado")
                .HasMaxLength(100);
            builder.Property(x => x.Matricula)
                .HasColumnName("matricula")
                .HasMaxLength(100);

            builder.HasMany(typeof(Mantenimiento), "MantenimientoAeronave");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
            builder.Ignore(x => x.MantenimientoAeronave);
            

        }
        public void Configure(EntityTypeBuilder<Mantenimiento> builder)
        {
            builder.ToTable("Mantenimiento");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FechaInicio)
                .HasColumnName("fechaInicio");

            builder.Property(x => x.FechaFin)
                .HasColumnName("fechaFin");

            builder.Property(x => x.Observaciones)
                .HasColumnName("fechaFin");
        }

    }
}
