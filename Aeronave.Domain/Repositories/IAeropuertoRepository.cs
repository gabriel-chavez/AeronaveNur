using Aeronave.Domain.Model.Aeropuertos;
using ShareKernel.Core;
using System;


namespace Aeronave.Domain.Repositories
{
    public interface IAeropuertoRepository : IRepository<Aeropuerto, Guid>
    {
    }
}
