using Aeronave.Domain.Model.Aeropuertos;
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
    public class AeropuertoRepository : IAeropuertoRepository
    {
        public readonly DbSet<Aeropuerto> _aeropuerto;

        public AeropuertoRepository(WriteDbContext aeropuerto)
        {
            _aeropuerto = aeropuerto.Aeropuerto;
        }

        public async Task CreateAsync(Aeropuerto obj)
        {
            await _aeropuerto.AddAsync(obj);
        }

        public async Task<Aeropuerto> FindByIdAsync(Guid id)
        {
            return await _aeropuerto.SingleAsync(x => x.Id == id);
        }

        public async Task<List<Aeropuerto>> RetornarAeronaves()
        {
            return await _aeropuerto.ToListAsync();
        }
    }
}
