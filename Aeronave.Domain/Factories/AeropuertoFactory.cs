using Aeronave.Domain.Model.Aeropuertos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeronave.Domain.Factories
{
    public class AeropuertoFactory : IAeropuertoFactory
    {
        public Aeropuerto Crear(string nombre, string pais, string ciudad)
        {
            return new Aeropuerto(nombre, pais, ciudad);
        }
    }
}
