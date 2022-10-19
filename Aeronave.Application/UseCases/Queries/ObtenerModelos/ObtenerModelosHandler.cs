using Aeronave.Application.Dto.Modelo;
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

namespace Aeronave.Application.UseCases.Queries.ObtenerModelos
{
    public class ObtenerModelosHandler : IRequestHandler<ObtenerModelosQuery, List<ModeloAeronaveDto>>
    {
        private readonly IModeloAeronaveRepository _modeloAereonaveRepository;
        private readonly ILogger<ObtenerModelosQuery> _logger;
        public ObtenerModelosHandler(IModeloAeronaveRepository modeloAereonaveRepository, ILogger<ObtenerModelosQuery> logger)
        {
            _modeloAereonaveRepository = modeloAereonaveRepository;
            _logger = logger;
        }


        public async Task<List<ModeloAeronaveDto>> Handle(ObtenerModelosQuery request, CancellationToken cancellationToken)
        {
            List<ModeloAeronaveDto> result = new List<ModeloAeronaveDto>();
            try
            {
                var aeronaves = await _modeloAereonaveRepository.RetornarAeronaves();
                foreach (var item in aeronaves)
                {
                    ModeloAeronaveDto modeloAeronaveDto = new ModeloAeronaveDto();
                    modeloAeronaveDto.Id = item.Id;
                    modeloAeronaveDto.CapacidadCarga = item.CapacidadCarga;
                    modeloAeronaveDto.CapacidadCargaCombustible = item.CapacidadCargaCombustible;
                    modeloAeronaveDto.Marca = item.Marca;
                    modeloAeronaveDto.Modelo = item.Modelo;

                    result.Add(modeloAeronaveDto);
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
