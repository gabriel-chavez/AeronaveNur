
using ShareKernel.Core;
using System;
using Aeronave.Domain.Model.Aeronaves;

namespace Aeronave.Domain.Repositories
{
    public interface IAeronaveRepository: IRepository<Aeronave.Domain.Model.Aeronaves.Aeronave, Guid>
    {
    }
}
