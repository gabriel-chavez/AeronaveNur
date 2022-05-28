using Aeronave.Domain.Event;
using Aeronave.Domain.Model.Aeronaves;
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
        public virtual DbSet<Aeronave.Domain.Model.Aeronaves.Aeronave> Aeronave { get; set; }
        public virtual DbSet<ModeloAeronave> ModeloAeronave { get; set; }
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


            modelBuilder.Ignore<DomainEvent>();
            modelBuilder.Ignore<AeronaveCreada>();
            modelBuilder.Ignore<AsientoAgregado>();
            modelBuilder.Ignore<MantenimientoAgregado>();
        }
    }
}

