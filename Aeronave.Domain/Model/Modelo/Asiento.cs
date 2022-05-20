using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeronave.Domain.Model.Modelo
{
    public class Asiento : Entity<Guid>
    {
        public int Fila { get; private set; }
        public int Columna { get; private set; }
        public string Area { get; private set; }
        internal Asiento(int fila, int columna, string area)
        {
            Id = Guid.NewGuid();
            Fila = fila;
            Columna = columna;
            Area = area;
        }
        internal void ModificarAsiento(int fila, int columna, string area)
        {
            Fila = fila;
            Columna = columna;
            Area = area;
        }
    }
}
