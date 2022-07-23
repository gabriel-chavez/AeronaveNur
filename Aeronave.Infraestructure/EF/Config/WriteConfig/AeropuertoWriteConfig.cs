using Aeronave.Domain.Model.Aeropuertos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeronave.Infraestructure.EF.Config.WriteConfig
{
    public class AeropuertoWriteConfig : IEntityTypeConfiguration<Aeropuerto>
    {
        public void Configure(EntityTypeBuilder<Aeropuerto> builder)
        {
            builder.ToTable("Aeropuerto");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Pais)
                .HasMaxLength(100);
            builder.Property(x => x.Nombre)
                .HasMaxLength(100);
            builder.Property(x => x.Ciudad)
                .HasMaxLength(100);


            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
