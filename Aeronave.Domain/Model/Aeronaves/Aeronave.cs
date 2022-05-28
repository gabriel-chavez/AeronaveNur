using Aeronave.Domain.Event;

using ShareKernel.Core;
using System;
using System.Collections.Generic;


namespace Aeronave.Domain.Model.Aeronaves
{
    public class Aeronave:AggregateRoot<Guid>
    {
        public Guid IdModelo { get; private set; }
        public Guid IdAereopuertoEstacionamiento { get; private set; }
        public int Estado { get; private set; }
        public string Matricula { get; private set; }
        public List<Mantenimiento> MantenimientoAeronave;

        public Aeronave(Guid idModelo, Guid idAereopuertoEstacionamiento, int estado, string matricula)
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
        public void ConsolidarRegistro()
        {
            var evento = new AeronaveCreada(IdModelo,IdAereopuertoEstacionamiento,Estado,Matricula);
            AddDomainEvent(evento);
        }
    }
}
