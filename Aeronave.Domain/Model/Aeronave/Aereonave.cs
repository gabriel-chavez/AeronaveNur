using Aeronave.Domain.Event;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeronave.Domain.Model.Aeronave
{
    public class Aereonave:AggregateRoot<Guid>
    {
        public Guid IdModelo { get; private set; }
        public Guid IdAereopuertoEstacionamiento { get; private set; }
        public int Estado { get; private set; }
        public string Matricula { get; set; }
        public List<Mantenimiento> MantenimientoAeronave;

        public Aereonave(Guid idModelo, Guid idAereopuertoEstacionamiento, int estado, string matricula = null)
        {
            Id = Guid.NewGuid();
            IdModelo = idModelo;
            IdAereopuertoEstacionamiento = idAereopuertoEstacionamiento;
            Estado = estado;
            Matricula = matricula;
            MantenimientoAeronave = new List<Mantenimiento>();
        }
        public void AgregarItem(DateTime fechaInicio, DateTime fechaFin, string observaciones) {
            var mantenimiento = new Mantenimiento(fechaInicio, fechaFin, observaciones);
            MantenimientoAeronave.Add(mantenimiento);
            AddDomainEvent(new MantenimientoAgregado(fechaInicio, fechaFin, observaciones));
        } 
    }
}
