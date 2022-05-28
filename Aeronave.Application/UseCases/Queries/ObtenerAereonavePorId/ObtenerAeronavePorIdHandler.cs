using Aeronave.Application.Dto.Aeronave;
using Aeronave.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aeronave.Application.UseCases.Queries.ObtenerAereonavePorId
{
    public class ObtenerAeronavePorIdHandler : IRequestHandler<ObtenerAeronavePorIdQuery, AeronaveDto>
    {
        private readonly IAeronaveRepository _aeronaveRepository;
        private readonly ILogger<ObtenerAeronavePorIdQuery> _logger;
        public ObtenerAeronavePorIdHandler(IAeronaveRepository aeronaveRepository, ILogger<ObtenerAeronavePorIdQuery> logger)
        {
            _aeronaveRepository = aeronaveRepository;
            _logger = logger;
        }
        public async Task<AeronaveDto> Handle(ObtenerAeronavePorIdQuery request, CancellationToken cancellationToken)
        {
            AeronaveDto aeronaveDto = null;
            try
            {
                Aeronave.Domain.Model.Aeronaves.Aeronave aeronave = await _aeronaveRepository.FindByIdAsync(request.Id);
                aeronaveDto = new AeronaveDto()
                {
                    Id = aeronave.Id,
                    IdModelo = aeronave.IdModelo,
                    IdAereopuertoEstacionamiento = aeronave.IdAereopuertoEstacionamiento,
                    Estado = aeronave.Estado,
                    Matricula = aeronave.Matricula
                };
                foreach (var item in aeronave.MantenimientoAeronave)
                {
                    aeronaveDto.MantenimientoAeronave.Add(new MantenimientoDto()
                    {
                        FechaInicio = item.FechaInicio,
                        FechaFin = item.FechaFin,
                        Observaciones = item.Observaciones
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener Pedido con id: { PedidoId }", request.Id);
            }
            return aeronaveDto;
        }
    }
}
