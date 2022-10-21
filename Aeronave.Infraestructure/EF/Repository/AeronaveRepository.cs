using Aeronave.Domain.Repositories;
using Aeronave.Infraestructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeronave.Infraestructure.EF.Repository
{
    [ExcludeFromCodeCoverage]
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

        public async Task<List<Domain.Model.Aeronaves.Aeronave>> RetornarAeronaves()
        {
            return await _aeronaves.ToListAsync();
        }

        public Task UpdateAsync(Domain.Model.Aeronaves.Aeronave obj)
        {
            _aeronaves.Update(obj);
            return Task.CompletedTask;
        }
    }
}
