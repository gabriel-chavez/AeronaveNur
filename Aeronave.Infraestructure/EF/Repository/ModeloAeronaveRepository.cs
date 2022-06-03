using Aeronave.Domain.Model.Modelo;
using Aeronave.Domain.Repositories;
using Aeronave.Infraestructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeronave.Infraestructure.EF.Repository
{
    public class ModeloAeronaveRepository : IModeloAeronaveRepository
    {
        public readonly DbSet<ModeloAeronave> _modeloAeronave;

        public ModeloAeronaveRepository(WriteDbContext modeloAeronave)
        {
            _modeloAeronave = modeloAeronave.ModeloAeronave;
        }

        public async Task CreateAsync(ModeloAeronave obj)
        {
            await _modeloAeronave.AddAsync(obj);
        }

        public async Task<ModeloAeronave> FindByIdAsync(Guid id)
        {
            //return await _modeloAeronave.Include("Asiento").SingleAsync(x => x.Id == id);
            return await _modeloAeronave.SingleAsync(x => x.Id == id);
        }

        public Task UpdateAsync(ModeloAeronave obj)
        {
            _modeloAeronave.Update(obj);
            return Task.CompletedTask;
        }
    }
}
