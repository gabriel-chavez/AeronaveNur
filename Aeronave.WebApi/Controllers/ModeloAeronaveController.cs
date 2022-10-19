using Aeronave.Application.Dto.Modelo;
using Aeronave.Application.UseCases.Command.RegistrarModelo;
using Aeronave.Application.UseCases.Queries.GetModeloByNombre;
using Aeronave.Application.UseCases.Queries.ObtenerModelos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aeronave.WebApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ModeloAeronaveController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ModeloAeronaveController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RegistrarModeloCommand command)
        {
            Guid id = await _mediator.Send(command);

            if (id == Guid.Empty)
                return BadRequest(new Result(false, "No se realizó el registro, favor intentar nuevamente"));

            return Ok(new Result<Guid>(id, true, "Registro de modelo realizado correctamente"));
        }
        [Route("{id:guid}")]
        [HttpGet]
        public async Task<IActionResult> GetModeloById(Guid id)
        {
            GetModeloByIdQuery query = new GetModeloByIdQuery(id);
            ModeloAeronaveDto result = await _mediator.Send(query);

            if (result == null)
                return NotFound(new Result(false, "No se encontraron registros con los parametros solicitados"));

            return Ok(new Result<ModeloAeronaveDto>(result, true, "Registro encontrado"));
        }
        [HttpGet]
        public async Task<IActionResult> GetModelos()
        {
            ObtenerModelosQuery query = new ObtenerModelosQuery();
            List<ModeloAeronaveDto> result = await _mediator.Send(query);

            if (result == null)
                return NotFound(new Result(false, "No se encontraron registros con los parametros solicitados"));

            return Ok(new Result<List<ModeloAeronaveDto>>(result, true, "Registro encontrado"));
        }
    }
}
