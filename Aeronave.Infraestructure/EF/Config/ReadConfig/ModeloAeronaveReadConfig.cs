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
    internal class ModeloAeronaveReadConfig : IEntityTypeConfiguration<ModeloAeronaveReadModel>, IEntityTypeConfiguration<AsientoReadModel>
    {
        public void Configure(EntityTypeBuilder<ModeloAeronaveReadModel> builder)
        {
            builder.ToTable("ModeloAeronave");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Modelo)
                .HasColumnName("modelo")
                .HasMaxLength(100);
            builder.Property(x => x.Marca)
                .HasColumnName("marca")
                .HasMaxLength(100);
            builder.Property(x => x.CapacidadCarga)
                .HasColumnName("capacidadCarga ")
                .HasColumnType("decimal")
                .HasPrecision(12, 2);
            builder.Property(x => x.CapacidadCargaCombustible)
                .HasColumnName("capacidadCargaCombustible")
                .HasColumnType("decimal")
                .HasPrecision(12, 2);

            builder.HasMany(x => x.Asientos)
                .WithOne(x => x.ModeloAeronave);
        }

        public void Configure(EntityTypeBuilder<AsientoReadModel> builder)
        {
            builder.ToTable("Asiento");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Fila)
               .HasColumnName("fila");

            builder.Property(x => x.Columna)
               .HasColumnName("columna");
            builder.Property(x => x.Area)
               .HasColumnName("area")
               .HasMaxLength(250);


        }
    }
}
