using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeronave.Domain.Factories
{
    public interface IAeronaveFactory
    {
        Aeronave.Domain.Model.Aeronaves.Aeronave Crear(Guid idModelo, Guid idAereopuertoEstacionamiento, int estado, string matricula);
    }
}
