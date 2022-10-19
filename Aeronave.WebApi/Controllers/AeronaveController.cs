using Aeronave.Application.Dto.Aeronave;
using Aeronave.Application.UseCases.Command.RegistrarAeronave;
using Aeronave.Application.UseCases.Queries.ObtenerAereonavePorId;
using Aeronave.Application.UseCases.Queries.ObtenerAeronaves;
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
    public class AeronaveController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AeronaveController(IMediator mediator)
        {

            _mediator = mediator;


        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RegistrarAeronaveCommand command)
        {

            Guid id = await _mediator.Send(command);

            if (id == Guid.Empty)
                return BadRequest(new Result(false, "No se realizó el registro, favor intentar nuevamente"));
            return Ok(new Result<Guid>(id, true, "Aeronave creada correctamente"));
        }
        [Route("{id:guid}")]
        [HttpGet]
        public async Task<IActionResult> GetAeronaveById(Guid id)
        {
            ObtenerAeronavePorIdQuery query = new ObtenerAeronavePorIdQuery(id);
            AeronaveDto result = await _mediator.Send(query);
            if (result == null)
                return NotFound(new Result(false, "No se encontraron registros con los parametros solicitados"));

            return Ok(new Result<AeronaveDto>(result, true, "Aeronave encontrada"));
        }
        [HttpGet]
        public async Task<IActionResult> GetAeronave()
        {
            ObtenerAeronavesQuery query = new ObtenerAeronavesQuery();
            List<AeronaveDto> result = await _mediator.Send(query);
            if (result == null)
                return NotFound(new Result(false, "No se encontraron registros con los parametros solicitados"));

            return Ok(new Result<List<AeronaveDto>>(result, true, "Listado encontrado"));
        }
    }
}
