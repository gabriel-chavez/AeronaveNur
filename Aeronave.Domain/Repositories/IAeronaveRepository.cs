
using ShareKernel.Core;
using System;
using Aeronave.Domain.Model.Aeronaves;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Aeronave.Domain.Repositories
{
    public interface IAeronaveRepository : IRepository<Aeronave.Domain.Model.Aeronaves.Aeronave, Guid>
    {
        Task<List<Aeronave.Domain.Model.Aeronaves.Aeronave>> RetornarAeronaves();
    }
}
