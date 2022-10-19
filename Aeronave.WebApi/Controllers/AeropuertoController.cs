using Aeronave.Application.Dto.Aeropuerto;
using Aeronave.Application.UseCases.Command.RegistrarAeropuerto;
using Aeronave.Application.UseCases.Queries.ObtenerAeropuertoPorId;
using Aeronave.Application.UseCases.Queries.ObtenerAeropuertos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aeronave.WebApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AeropuertoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AeropuertoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RegistrarAeropuertoCommand command)
        {
            Guid id = await _mediator.Send(command);

            if (id == Guid.Empty)
                return BadRequest(new Result(false, "No se realizó el registro del aeropuerto, favor intente nuevamente"));

            return Ok(new Result<Guid>(id, true, "El aeropuerto se registro correctamente"));
        }
        [Route("{id:guid}")]
        [HttpGet]
        public async Task<IActionResult> GetAeropuertoById(Guid id)
        {
            ObtenerAeropuertoPorIdQuery query = new ObtenerAeropuertoPorIdQuery(id);
            AeropuertoDto result = await _mediator.Send(query);

            if (result == null)
                return NotFound(new Result(false, "No se encontraron registros con los parametros solicitados"));

            return Ok(new Result<AeropuertoDto>(result, true, "Registro encontrado"));
        }
        [HttpGet]
        public async Task<IActionResult> GetAeropuertos()
        {
            ObtenerAeropuertosQuery query = new ObtenerAeropuertosQuery();
            List<AeropuertoDto> result = await _mediator.Send(query);

            if (result == null)
                return NotFound(new Result(false, "No se encontraron registros con los parametros solicitados"));

            return Ok(new Result<List<AeropuertoDto>>(result, true, "Registro encontrado"));
        }
    }
}
