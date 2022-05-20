using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeronave.Domain.Event
{
    public record AsientoAgregado : DomainEvent
    {
        public int Fila { get; private set; }
        public int Columna { get; private set; }
        public string Area { get; private set; }

        public AsientoAgregado(int fila, int columna, string area) : base(DateTime.Now)
        {
            Fila = fila;
            Columna = columna;
            Area = area;
        }
    }
}
