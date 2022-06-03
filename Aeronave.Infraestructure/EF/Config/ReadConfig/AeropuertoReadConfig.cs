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
    internal class AeropuertoReadConfig : IEntityTypeConfiguration<AeropuertoReadModel>
    {
        public void Configure(EntityTypeBuilder<AeropuertoReadModel> builder)
        {
            builder.ToTable("Aeropuerto");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nombre)
               // .HasColumnName("nombre")
                .HasMaxLength(500);

            builder.Property(x => x.Pais)
               // .HasColumnName("pais")
                .HasMaxLength(500);

            builder.Property(x => x.Ciudad)
              //  .HasColumnName("ciudad")
                .HasMaxLength(500);
        }
    }
}
