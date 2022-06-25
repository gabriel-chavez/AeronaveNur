using MediatR;
using System;
using System.Diagnostics.CodeAnalysis;

namespace ShareKernel.Core
{
    public abstract record DomainEvent : INotification
    {
        [ExcludeFromCodeCoverage]
        public DateTime OccuredOn { get; }
        [ExcludeFromCodeCoverage]
        public Guid Id { get; }

        protected DomainEvent(DateTime occuredOn)
        {
            OccuredOn = occuredOn;
            Id = Guid.NewGuid();
        }
    }
}
