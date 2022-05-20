using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeronave.Domain.Event
{
    public record MantenimientoAgregado :DomainEvent
    {
        public DateTime FechaInicio { get; private set; }

        public DateTime FechaFin { get; private set; }
        public string Observaciones { get; private set; }
        public MantenimientoAgregado(DateTime fechaInicio, DateTime fechaFin, string observaciones) : base(DateTime.Now)
        {
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            Observaciones = observaciones;
        }

       
    }
}
