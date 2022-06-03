using Aeronave.Domain.Repositories;
using Aeronave.Infraestructure.EF.Contexts;
using MediatR;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeronave.Infraestructure.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WriteDbContext _context;
       // private readonly IMediator _mediator;

        public UnitOfWork(WriteDbContext context)
        {
            _context = context;
         //   _mediator = mediator;
        }

        public async Task Commit()
        {
            //Publicar eventos de dominio
            //var domainEvents = _context.ChangeTracker.Entries<Entity<Guid>>()
            //    .Select(x => x.Entity.DomainEvents)
            //    .SelectMany(x => x)
            //    .ToArray();

            //foreach (var @event in domainEvents)
            //{
            //    await _mediator.Publish(@event);
            //}

            await _context.SaveChangesAsync();
        }
    }
}
