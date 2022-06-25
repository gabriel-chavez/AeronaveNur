using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeronave.Application.Services
{
    public interface IAeronaveService
    {
        Task<string> GenerarMatriculaAleatoria();
    }
}
