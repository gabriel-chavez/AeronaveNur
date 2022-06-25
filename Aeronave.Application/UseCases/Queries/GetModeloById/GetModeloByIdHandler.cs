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

namespace Aeronave.Application.UseCases.Queries.GetModeloByNombre
{
    public class GetModeloByIdHandler : IRequestHandler<GetModeloByIdQuery, ModeloAeronaveDto>
    {
        private readonly IModeloAeronaveRepository _modeloAereonaveRepository;
        private readonly ILogger<GetModeloByIdQuery> _logger;
        public GetModeloByIdHandler(IModeloAeronaveRepository modeloAereonaveRepository, ILogger<GetModeloByIdQuery> logger)
        {
            _modeloAereonaveRepository = modeloAereonaveRepository;
            _logger = logger;
        }

        public async Task<ModeloAeronaveDto> Handle(GetModeloByIdQuery request, CancellationToken cancellationToken)
        {
            ModeloAeronaveDto result = null;
            try
            {
                ModeloAeronave objPedido = await _modeloAereonaveRepository.FindByIdAsync(request.Id);

                result = new ModeloAeronaveDto()
                {
                    Id = objPedido.Id,
                    CapacidadCargaCombustible = objPedido.CapacidadCargaCombustible,
                    CapacidadCarga = objPedido.CapacidadCarga,
                    Marca = objPedido.Marca,
                    Modelo = objPedido.Modelo

                };
               
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener Modelo con id: { PedidoId }", request.Id);
            }
            return result;
        }
    }
}
