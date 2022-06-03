using Aeronave.Application.Dto.Aeropuerto;
using Aeronave.Application.UseCases.Command.RegistrarAeropuerto;
using Aeronave.Application.UseCases.Queries.ObtenerAeropuertoPorId;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
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
                return BadRequest();

            return Ok(id);
        }
        [Route("{id:guid}")]
        [HttpGet]
        public async Task<IActionResult> GetAeronaveById(Guid id)
        {
            ObtenerAeropuertoPorIdQuery query = new ObtenerAeropuertoPorIdQuery(id);
            AeropuertoDto result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
