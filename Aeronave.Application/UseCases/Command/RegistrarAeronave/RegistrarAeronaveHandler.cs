using Aeronave.Application.Dto.Aeronave;
using Aeronave.Domain.Factories;
using Aeronave.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aeronave.Application.UseCases.Command.RegistrarAeronave
{
    public class RegistrarAeronaveHandler : IRequestHandler<RegistrarAeronaveCommand, Guid>
    {
        private readonly IAeronaveRepository _aeronaveRepository;
        private readonly ILogger<RegistrarAeronaveHandler> _logger;
        private readonly IAeronaveFactory _aeronaveFactory;
        private readonly IUnitOfWork _unitOfWork;
        public RegistrarAeronaveHandler(IAeronaveRepository aeronaveRepository, ILogger<RegistrarAeronaveHandler> logger, IAeronaveFactory aeronaveFactory, IUnitOfWork unitOfWork)
        {
            _aeronaveRepository = aeronaveRepository;
            _logger = logger;
            _aeronaveFactory = aeronaveFactory;
            _unitOfWork = unitOfWork;
        }

        
        public async Task<Guid> Handle(RegistrarAeronaveCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Aeronave.Domain.Model.Aeronaves.Aeronave aeronave = _aeronaveFactory.Crear(request.IdModelo, request.IdAereopuertoEstacionamiento, request.Estado, request.Matricula);
                foreach (var item in request.MantenimientoAeronave)
                {
                    aeronave.AgregarItem(item.FechaInicio, item.FechaFin, item.Observaciones);
                }
                aeronave.ConsolidarRegistro();
                await _aeronaveRepository.CreateAsync(aeronave);
                await _unitOfWork.Commit();
                return aeronave.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear pedido");
            }
            return Guid.Empty;
        }
    }

}
