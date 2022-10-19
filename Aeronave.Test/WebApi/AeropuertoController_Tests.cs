using Aeronave.Application.UseCases.Command.RegistrarAeropuerto;
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
    public class AeropuertoController_Tests
    {
        [Fact]
        public void Create_Correctly()
        {
            var mediator = new Mock<IMediator>();
            AeropuertoController aeropuertoController = new AeropuertoController(mediator.Object);
            var nombre = "LPB, Bolivia";
            var pais = "Bolivia";
            var ciudad = "La Paz";
            var command = new RegistrarAeropuertoCommand(nombre, pais, ciudad);


            var resultado = aeropuertoController.Create(command);

            Assert.NotNull(resultado);

        }
        [Fact]
        public void Get_Correctly()
        {
            var mediator = new Mock<IMediator>();
            AeropuertoController aeropuertoController = new AeropuertoController(mediator.Object);

            var id = new Guid("3FA85F64-5717-4562-B3FC-2C963F66AFA6");


            var resultado = aeropuertoController.GetAeropuertoById(id);

            Assert.NotNull(resultado);

        }
    }
}
