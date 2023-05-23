using Aeronave.Domain.Event;
using MassTransit;
using MediatR;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aeronave.Application.UseCases.DomainEventHandler.Aeronave
{
    public class PublishIntegrationEventWhenAeronaveCreadaHandler : INotificationHandler<ConfirmedDomainEvent<AeronaveCreada>>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public PublishIntegrationEventWhenAeronaveCreadaHandler(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task Handle(ConfirmedDomainEvent<AeronaveCreada> notification, CancellationToken cancellationToken)
        {
            //ShareKernel.IntegrationEvents.AeronaveCreada evento = new ShareKernel.IntegrationEvents.AeronaveCreada()
            //{
            //    IdAereopuertoEstacionamiento = notification.DomainEvent.IdAereopuertoEstacionamiento,
            //    IdModelo = notification.DomainEvent.IdModelo,
            //    Estado = notification.DomainEvent.Estado,
            //    Matricula = notification.DomainEvent.Matricula
            //};
            //await _publishEndpoint.Publish<ShareKernel.IntegrationEvents.AeronaveCreada>(evento);

        }
    }
}
