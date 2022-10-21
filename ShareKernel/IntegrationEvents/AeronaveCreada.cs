using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareKernel.IntegrationEvents
{
    [ExcludeFromCodeCoverage]
    public record AeronaveCreada : IntegrationEvent

    {
        public Guid IdModelo { get; set; }
        public Guid IdAereopuertoEstacionamiento { get; set; }
        public int Estado { get; set; }
        public string Matricula { get; set; }
    }
}
