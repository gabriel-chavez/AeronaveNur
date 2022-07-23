using Aeronave.Application.Dto.Aeronave;
using Aeronave.Application.UseCases.Command.RegistrarAeronave;
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
    public class AeronaveController_Tests
    {
        [Fact]
        public void Create_Correctly()
        {
            var mediator = new Mock<IMediator>();
            AeronaveController aeronaveController = new AeronaveController(mediator.Object);
            var mantenimientoDto = new List<MantenimientoDto>();
            mantenimientoDto.Add(new MantenimientoDto() { FechaInicio = DateTime.Now, FechaFin = DateTime.Now, Observaciones = "Sin mantenimiento registrado" });
            mantenimientoDto.Add(new MantenimientoDto() { FechaInicio = DateTime.Now, FechaFin = DateTime.Now, Observaciones = "Sin mantenimiento registrado" });
            mantenimientoDto.Add(new MantenimientoDto() { FechaInicio = DateTime.Now, FechaFin = DateTime.Now, Observaciones = "Sin mantenimiento registrado" });
            mantenimientoDto.Add(new MantenimientoDto() { FechaInicio = DateTime.Now, FechaFin = DateTime.Now, Observaciones = "Sin mantenimiento registrado" });
            var modeloId = new Guid("3FA85F64-5717-4562-B3FC-2C963F66AFA6");
            var aeropuertoId = new Guid("3FA85F64-5717-4562-B3FC-2C963F66AFA6");
            var estado = 0;
            var matricula = "CP-1128";
            var registrarAeronaveCommand = new RegistrarAeronaveCommand(mantenimientoDto, modeloId, aeropuertoId, estado, matricula);

            var resultado = aeronaveController.Create(registrarAeronaveCommand);

            Assert.NotNull(resultado);

        }
        [Fact]
        public void Get_Correctly()
        {
            var mediator = new Mock<IMediator>();
            AeronaveController aeronaveController = new AeronaveController(mediator.Object);

            var id = new Guid("3FA85F64-5717-4562-B3FC-2C963F66AFA6");


            var resultado = aeronaveController.GetAeronaveById(id);

            Assert.NotNull(resultado);

        }
    }
}
