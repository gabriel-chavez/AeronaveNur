using ShareKernel.Core;
using System;


namespace Aeronave.Domain.Model.Aeronaves
{
    public class Mantenimiento: Entity<Guid>
    {
        public DateTime FechaInicio { get; private set; }

        public DateTime FechaFin { get; private set; }
        public string Observaciones { get; private set; }

        internal Mantenimiento(DateTime fechaInicio, DateTime fechaFin, string observaciones)
        {
            Id = Guid.NewGuid();
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            Observaciones = observaciones;
        }
        private Mantenimiento()
        {
        }
        internal void ModificarDatos(DateTime fechaInicio, DateTime fechaFin, string observaciones)
        {
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            Observaciones = observaciones;
        }

    }
}
