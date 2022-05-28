using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeronave.Domain.Factories
{
    public class AeronaveFactory : IAeronaveFactory
    {
        public Model.Aeronaves.Aeronave Crear(Guid idModelo, Guid idAereopuertoEstacionamiento, int estado, string matricula)
        {
            return new Model.Aeronaves.Aeronave(idModelo, idAereopuertoEstacionamiento, estado, matricula);
        }
    }
}
