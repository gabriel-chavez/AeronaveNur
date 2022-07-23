using Aeronave.Domain.Factories;
using Aeronave.Domain.Model.Aeropuertos;
using Aeronave.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aeronave.Application.UseCases.Command.RegistrarAeropuerto
{
    public class RegistrarAeropuertoHandler : IRequestHandler<RegistrarAeropuertoCommand, Guid>
    {
        private readonly IAeropuertoRepository _aeropuertoRepository;
        private readonly ILogger<RegistrarAeropuertoHandler> _logger;
        private readonly IAeropuertoFactory _aeropuertoFactory;
        private readonly IUnitOfWork _unitOfWork;
        public RegistrarAeropuertoHandler(IAeropuertoRepository aeropuertoRepository, ILogger<RegistrarAeropuertoHandler> logger, IAeropuertoFactory aeropuertoFactory, IUnitOfWork unitOfWork)
        {
            _aeropuertoRepository = aeropuertoRepository;
            _logger = logger;
            _aeropuertoFactory = aeropuertoFactory;
            _unitOfWork = unitOfWork;
        }



        public async Task<Guid> Handle(RegistrarAeropuertoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Aeropuerto aeropuerto = _aeropuertoFactory.Crear(request.Nombre, request.Pais, request.Ciudad);
                await _aeropuertoRepository.CreateAsync(aeropuerto);
                await _unitOfWork.Commit();
                return aeropuerto.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear el aeropuerto");
            }
            return Guid.Empty;
        }
    }
}
