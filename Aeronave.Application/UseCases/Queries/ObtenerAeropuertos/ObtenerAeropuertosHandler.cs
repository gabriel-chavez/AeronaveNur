using Aeronave.Application.Dto.Aeropuerto;
using Aeronave.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aeronave.Application.UseCases.Queries.ObtenerAeropuertos
{
    public class ObtenerAeropuertosHandler : IRequestHandler<ObtenerAeropuertosQuery, List<AeropuertoDto>>
    {
        private readonly IAeropuertoRepository _aeropuertoRepository;
        private readonly ILogger<ObtenerAeropuertosQuery> _logger;
        public ObtenerAeropuertosHandler(IAeropuertoRepository aeropuertoRepository, ILogger<ObtenerAeropuertosQuery> logger)
        {
            _aeropuertoRepository = aeropuertoRepository;
            _logger = logger;
        }


        public async Task<List<AeropuertoDto>> Handle(ObtenerAeropuertosQuery request, CancellationToken cancellationToken)
        {
            List<AeropuertoDto> result = new List<AeropuertoDto>();
            try
            {
                var aeronaves = await _aeropuertoRepository.RetornarAeronaves();
                foreach (var item in aeronaves)
                {
                    AeropuertoDto aeropuertoDto = new AeropuertoDto();
                    aeropuertoDto.Id = item.Id;
                    aeropuertoDto.Nombre = item.Nombre;
                    aeropuertoDto.Pais = item.Pais;
                    aeropuertoDto.Ciudad = item.Ciudad;
                    result.Add(aeropuertoDto);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al retornar los modelos");
            }
            return result;
        }
    }
}
