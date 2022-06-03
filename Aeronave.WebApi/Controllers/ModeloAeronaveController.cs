using Aeronave.Application.Dto.Modelo;
using Aeronave.Application.UseCases.Command.RegistrarModelo;
using Aeronave.Application.UseCases.Queries.GetModeloByNombre;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
                return BadRequest();

            return Ok(id);
        }
        [Route("{id:guid}")]
        [HttpGet]
        public async Task<IActionResult> GetPedidoById(Guid id)
        {
            GetModeloByIdQuery query = new GetModeloByIdQuery(id);
            ModeloAeronaveDto result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
