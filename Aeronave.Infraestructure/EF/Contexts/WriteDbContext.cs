using Aeronave.Domain.Event;
using Aeronave.Domain.Model.Aeronaves;
using Aeronave.Domain.Model.Aeropuertos;
using Aeronave.Domain.Model.Modelo;
using Aeronave.Infraestructure.EF.Config.WriteConfig;
using Microsoft.EntityFrameworkCore;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeronave.Infraestructure.EF.Contexts
{
    public class WriteDbContext : DbContext
    {
        public virtual DbSet<Aeronave.Domain.Model.Aeronaves.Aeronave> Aeronave { get; private set; }
        public virtual DbSet<ModeloAeronave> ModeloAeronave { get; private set; }
        public virtual DbSet<Aeropuerto> Aeropuerto { get; private set; }
        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var aeronaveConfig = new AeronaveWriteConfig();
            modelBuilder.ApplyConfiguration<Aeronave.Domain.Model.Aeronaves.Aeronave>(aeronaveConfig);
            modelBuilder.ApplyConfiguration<Mantenimiento>(aeronaveConfig);

            var modeloAeronaveConfig = new ModeloAeronaveWriteConfig();
            modelBuilder.ApplyConfiguration<ModeloAeronave>(modeloAeronaveConfig);
            modelBuilder.ApplyConfiguration<Asiento>(modeloAeronaveConfig);

            var aeropuertoConfig = new AeropuertoWriteConfig();
            modelBuilder.ApplyConfiguration<Aeropuerto>(aeropuertoConfig);
      

            modelBuilder.Ignore<DomainEvent>();
            modelBuilder.Ignore<AeronaveCreada>();
            modelBuilder.Ignore<AsientoAgregado>();
            modelBuilder.Ignore<MantenimientoAgregado>();
        }
    }
}

