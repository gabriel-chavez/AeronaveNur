using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeronave.Domain.Event
{
    public record AeronaveCreada:DomainEvent
    {
        public Guid IdModelo { get; private set; }
        public Guid IdAereopuertoEstacionamiento { get; private set; }
        public int Estado { get; private set; }
        public string Matricula { get; private set; }
        public AeronaveCreada(Guid idModelo, Guid idAereopuertoEstacionamiento, int estado, string matricula = null) : base(DateTime.Now)
        {
            IdModelo = idModelo;
            IdAereopuertoEstacionamiento = idAereopuertoEstacionamiento;
            Estado = estado;
            Matricula = matricula;
        }
    }
}
