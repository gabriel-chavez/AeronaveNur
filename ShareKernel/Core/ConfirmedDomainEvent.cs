using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareKernel.Core
{
    public class ConfirmedDomainEvent<T> : INotification where T : DomainEvent
    {
        public T DomainEvent { get; }
        public ConfirmedDomainEvent(T domainEvent)
        {
            DomainEvent = domainEvent;
        }
    }
}
