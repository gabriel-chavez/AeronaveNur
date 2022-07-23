using Aeronave.Application.Dto.Aeropuerto;
using Aeronave.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using Aeronave.Domain.Model.Aeropuertos;
using System.Threading;
using System.Threading.Tasks;

namespace Aeronave.Application.UseCases.Queries.ObtenerAeropuertoPorId
{
    public class ObtenerAeropuertoPorIdHandler : IRequestHandler<ObtenerAeropuertoPorIdQuery, AeropuertoDto>
    {
        private readonly IAeropuertoRepository _aeropuertoRepository;
        private readonly ILogger<ObtenerAeropuertoPorIdQuery> _logger;
        public ObtenerAeropuertoPorIdHandler(IAeropuertoRepository aeropuertoRepository, ILogger<ObtenerAeropuertoPorIdQuery> logger)
        {
            _aeropuertoRepository = aeropuertoRepository;
            _logger = logger;
        }

        public async Task<AeropuertoDto> Handle(ObtenerAeropuertoPorIdQuery request, CancellationToken cancellationToken)
        {
            AeropuertoDto result = null;
            try
            {
                Aeropuerto objPedido = await _aeropuertoRepository.FindByIdAsync(request.Id);

                result = new AeropuertoDto()
                {
                    Id = objPedido.Id,
                    Pais = objPedido.Pais,
                    Ciudad = objPedido.Nombre,
                    Nombre = objPedido.Ciudad

                };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener Aueropuerto con id: { AeropuertoId }", request.Id);
            }
            return result;
        }


    }
}
