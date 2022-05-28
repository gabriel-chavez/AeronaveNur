using Aeronave.Domain.Model.Modelo;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeronave.Domain.Repositories
{
    public interface IModeloAereonaveRepository : IRepository<ModeloAeronave, Guid>
    {
        Task UpdateAsync(ModeloAeronave obj);
    }
}
