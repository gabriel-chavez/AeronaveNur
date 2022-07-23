using Aeronave.Application.Dto.Aeronave;
using Aeronave.Application.UseCases.Command.RegistrarAeronave;
using Aeronave.Application.UseCases.Queries.ObtenerAereonavePorId;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
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
                return BadRequest();
            return Ok(id);
        }
        [Route("{id:guid}")]
        [HttpGet]
        public async Task<IActionResult> GetAeronaveById(Guid id)
        {
            ObtenerAeronavePorIdQuery query = new ObtenerAeronavePorIdQuery(id);
            AeronaveDto result = await _mediator.Send(query);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

    }
}
