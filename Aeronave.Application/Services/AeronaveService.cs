using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeronave.Application.Services
{
    public class AeronaveService : IAeronaveService
    {
        public Task<string> GenerarMatriculaAleatoria() => Task.FromResult("CP-1128");

    }
}
