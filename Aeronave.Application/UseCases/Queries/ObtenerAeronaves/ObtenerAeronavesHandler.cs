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

namespace Aeronave.Application.UseCases.Queries.ObtenerAeronaves
{
    public class ObtenerAeronavesHandler : IRequestHandler<ObtenerAeronavesQuery, List<AeronaveDto>>
    {
        private readonly IAeronaveRepository _aeronaveRepository;
        private readonly ILogger<ObtenerAeronavesQuery> _logger;
        public ObtenerAeronavesHandler(IAeronaveRepository aeronaveRepository, ILogger<ObtenerAeronavesQuery> logger)
        {
            _aeronaveRepository = aeronaveRepository;
            _logger = logger;
        }

        public async Task<List<AeronaveDto>> Handle(ObtenerAeronavesQuery request, CancellationToken cancellationToken)
        {
            List<AeronaveDto> result = new List<AeronaveDto>();
            try
            {
                var aeronaves = await _aeronaveRepository.RetornarAeronaves();
                foreach (var item in aeronaves)
                {
                    AeronaveDto aeronaveDto = new AeronaveDto();
                    aeronaveDto.Id = item.Id;
                    aeronaveDto.ModeloAeronaveId = item.ModeloAeronaveId;

                    aeronaveDto.Estado = item.Estado;
                    aeronaveDto.Matricula = item.Matricula;
                    aeronaveDto.MantenimientoAeronave = null;
                    result.Add(aeronaveDto);
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
