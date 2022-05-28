using Aeronave.Domain.Model.Modelo;
using Aeronave.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeronave.Infraestructure.EF.Repository
{
    public class ModeloAeronaveRepository : IModeloAeronaveRepository
    {
        public Task CreateAsync(ModeloAeronave obj)
        {
            throw new NotImplementedException();
        }

        public Task<ModeloAeronave> FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ModeloAeronave obj)
        {
            throw new NotImplementedException();
        }
    }
}
