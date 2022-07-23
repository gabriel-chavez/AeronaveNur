using Aeronave.Infraestructure.EF.ReadModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeronave.Infraestructure.EF.Config.ReadConfig
{
    public class AeronaveReadConfig : IEntityTypeConfiguration<AeronaveReadModel>, IEntityTypeConfiguration<MantenimientoReadModel>
    {
        public void Configure(EntityTypeBuilder<AeronaveReadModel> builder)
        {
            builder.ToTable("Aeronave");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Estado)
                //  .HasColumnName("estado")
                .HasMaxLength(100);
            builder.Property(x => x.Matricula)
                //   .HasColumnName("matricula")
                .HasMaxLength(100);

            builder.HasMany(x => x.MantenimientoAeronave)
                .WithOne(x => x.Aeronave);




        }

        public void Configure(EntityTypeBuilder<MantenimientoReadModel> builder)
        {
            builder.ToTable("Mantenimiento");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FechaInicio);
            //  .HasColumnName("fechaInicio");

            builder.Property(x => x.FechaFin);
            //    .HasColumnName("fechaFin");

            builder.Property(x => x.Observaciones);
            //   .HasColumnName("observaciones");


        }
    }
}
