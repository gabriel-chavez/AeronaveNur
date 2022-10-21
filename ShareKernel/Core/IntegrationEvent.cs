using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareKernel.Core
{
    [ExcludeFromCodeCoverage]
    public abstract record IntegrationEvent
    {
        public DateTime OcurredOn { get; }
        public Guid EventId { get; set; }
        public IntegrationEvent()
        {
            EventId = Guid.NewGuid();
            OcurredOn = DateTime.UtcNow;
        }
    }
}
