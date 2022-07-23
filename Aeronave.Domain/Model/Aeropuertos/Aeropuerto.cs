using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeronave.Domain.Model.Aeropuertos
{
    public class Aeropuerto : AggregateRoot<Guid>
    {
        public string Nombre { get; private set; }
        public string Pais { get; private set; }
        public string Ciudad { get; private set; }
        public Aeropuerto(string nombre, string pais, string ciudad)
        {
            Id = Guid.NewGuid();
            Nombre = nombre;
            Pais = pais;
            Ciudad = ciudad;
        }
    }
}
