using Aeronave.Domain.Model.Aeropuertos;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aeronave.Domain.Repositories
{
    public interface IAeropuertoRepository : IRepository<Aeropuerto, Guid>
    {
        Task<List<Aeropuerto>> RetornarAeronaves();
    }
}
