using Aeronave.Application.Dto.Modelo;
using Aeronave.Application.UseCases.Command.RegistrarModelo;
using Aeronave.WebApi.Controllers;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aeronave.Test.WebApi
{
    public class ModeloAeronaveController_Tests
    {
        [Fact]
        public void Create_Correctly()
        {
            var mediator = new Mock<IMediator>();
            var modelo = "767-300 ER";
            var marca = "Boeing";
            decimal capacidadCarga = 39790.00m;
            decimal capacidadCargaCombustible = 91380.00m;
            var asiento = new List<AsientoDto>();
            var command = new RegistrarModeloCommand(modelo, marca, capacidadCarga, capacidadCargaCombustible, asiento);

            ModeloAeronaveController aeropuertoController = new ModeloAeronaveController(mediator.Object);         

            var resultado = aeropuertoController.Create(command);

            Assert.NotNull(resultado);

        }
        [Fact]
        public void Get_Correctly()
        {
            var mediator = new Mock<IMediator>();
            ModeloAeronaveController aeropuertoController = new ModeloAeronaveController(mediator.Object);

            var id = new Guid("3FA85F64-5717-4562-B3FC-2C963F66AFA6");


            var resultado = aeropuertoController.GetPedidoById(id);

            Assert.NotNull(resultado);

        }
    }
}
