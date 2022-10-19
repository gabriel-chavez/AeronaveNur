using Aeronave.Domain.Model.Modelo;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aeronave.Domain.Repositories
{
    public interface IModeloAeronaveRepository : IRepository<ModeloAeronave, Guid>
    {
        Task UpdateAsync(ModeloAeronave obj);
        Task<List<ModeloAeronave>> RetornarAeronaves();
    }
}
