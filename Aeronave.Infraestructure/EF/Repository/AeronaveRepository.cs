using Aeronave.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeronave.Infraestructure.EF.Repository
{
    public class AeronaveRepository : IAeronaveRepository
    {
        public Task CreateAsync(Domain.Model.Aeronaves.Aeronave obj)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Model.Aeronaves.Aeronave> FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
