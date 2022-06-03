using Aeronave.Domain.Event;
using Aeronave.Infraestructure.EF.Config.ReadConfig;
using Aeronave.Infraestructure.EF.ReadModel;
using Microsoft.EntityFrameworkCore;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeronave.Infraestructure.EF.Contexts
{
    public  class ReadDbContext : DbContext
    {
        public virtual DbSet<AeronaveReadModel> Aeronave { get; private set; }
        public virtual DbSet<ModeloAeronaveReadModel> ModeloAeronave { get; private set; }
        public virtual DbSet<AeropuertoReadModel> Aeropuerto { get; private set; }
        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {

        }
        public ReadDbContext()
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var aeronaveConfig = new AeronaveReadConfig();
            modelBuilder.ApplyConfiguration<AeronaveReadModel>(aeronaveConfig);
            modelBuilder.ApplyConfiguration<MantenimientoReadModel>(aeronaveConfig);

            var modeloAeronaveConfig = new ModeloAeronaveReadConfig();
            modelBuilder.ApplyConfiguration<ModeloAeronaveReadModel>(modeloAeronaveConfig);
            modelBuilder.ApplyConfiguration<AsientoReadModel>(modeloAeronaveConfig);

            var aeropuertoConfig = new AeropuertoReadConfig();
            modelBuilder.ApplyConfiguration<AeropuertoReadModel>(aeropuertoConfig);
         

            modelBuilder.Ignore<DomainEvent>();
            modelBuilder.Ignore<AeronaveCreada>();            
            modelBuilder.Ignore<AsientoAgregado>();
            modelBuilder.Ignore<MantenimientoAgregado>();

        }
            
    }
}
