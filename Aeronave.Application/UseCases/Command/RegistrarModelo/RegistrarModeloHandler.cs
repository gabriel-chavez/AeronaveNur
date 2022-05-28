using Aeronave.Domain.Factories;
using Aeronave.Domain.Model.Modelo;
using Aeronave.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aeronave.Application.UseCases.Command.RegistrarModelo
{
    public class RegistrarModeloHandler : IRequestHandler<RegistrarModeloCommand, Guid>
    {
        private readonly IModeloAeronaveRepository _modeloAeronaveRepository;
        private readonly ILogger<RegistrarModeloHandler> _logger;
        private readonly IModeloAeronaveFactory _modeloAeronaveFactory;
        private readonly IUnitOfWork _unitOfWork;
        public RegistrarModeloHandler(IModeloAeronaveRepository modeloAeronaveRepository, ILogger<RegistrarModeloHandler> logger, IModeloAeronaveFactory modeloAeronaveFactory, IUnitOfWork unitOfWork)
        {
            _modeloAeronaveRepository = modeloAeronaveRepository;
            _logger = logger;
            _modeloAeronaveFactory = modeloAeronaveFactory;
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(RegistrarModeloCommand request, CancellationToken cancellationToken)
        {
            try
            {
                ModeloAeronave modeloAeronave = _modeloAeronaveFactory.Crear(request.Modelo, request.Marca, request.CapacidadCarga, request.CapacidadCargaCombustible);
                foreach (var item in modeloAeronave.Asientos)
                {
                    modeloAeronave.AgregarAsientos(item.Fila, item.Columna, item.Area);
                }
                await _modeloAeronaveRepository.CreateAsync(modeloAeronave);
                await _unitOfWork.Commit();
                return modeloAeronave.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear pedido");
            }
            return Guid.Empty;
        }
    }
}
