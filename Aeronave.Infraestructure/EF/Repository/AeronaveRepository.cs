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
    public class AeronaveRepository : IAeronaveRepository
    {
        public readonly DbSet<Aeronave.Domain.Model.Aeronaves.Aeronave> _aeronaves;

        public AeronaveRepository(WriteDbContext aeronaves)
        {
            _aeronaves = aeronaves.Aeronave;
        }

        public async Task CreateAsync(Domain.Model.Aeronaves.Aeronave obj)
        {
            await _aeronaves.AddAsync(obj);
        }

        public async Task<Domain.Model.Aeronaves.Aeronave> FindByIdAsync(Guid id)
        {
            return await _aeronaves.SingleAsync(x => x.Id == id);
        }
        public Task UpdateAsync(Domain.Model.Aeronaves.Aeronave obj)
        {
            _aeronaves.Update(obj);
            return Task.CompletedTask;
        }
    }
}
