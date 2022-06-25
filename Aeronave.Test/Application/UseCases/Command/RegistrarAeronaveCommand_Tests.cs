using Aeronave.Application.Dto.Aeronave;
using Aeronave.Application.UseCases.Command.RegistrarAeronave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aeronave.Test.Application.UseCases.Command
{
    public class RegistrarAeronaveCommand_Tests
    {
        [Fact]
        public void RegistrarAeronaveCommand_DataValid()
        {
            var mantenimientoDto = new List<MantenimientoDto>();
            mantenimientoDto.Add(new MantenimientoDto() { FechaInicio = DateTime.Now, FechaFin = DateTime.Now, Observaciones = "Sin mantenimiento registrado" });
            mantenimientoDto.Add(new MantenimientoDto() { FechaInicio = DateTime.Now, FechaFin = DateTime.Now, Observaciones = "Sin mantenimiento registrado" });
            mantenimientoDto.Add(new MantenimientoDto() { FechaInicio = DateTime.Now, FechaFin = DateTime.Now, Observaciones = "Sin mantenimiento registrado" });
            mantenimientoDto.Add(new MantenimientoDto() { FechaInicio = DateTime.Now, FechaFin = DateTime.Now, Observaciones = "Sin mantenimiento registrado" });
            var modeloId = new Guid("3FA85F64-5717-4562-B3FC-2C963F66AFA6");
            var aeropuertoId = new Guid("3FA85F64-5717-4562-B3FC-2C963F66AFA6");
            var estado = 0;
            var matricula = "CP-1128";
            var command = new RegistrarAeronaveCommand(mantenimientoDto, modeloId, aeropuertoId, estado, matricula);

            Assert.Equal(mantenimientoDto, command.MantenimientoAeronave);
            Assert.Equal(modeloId, command.IdModelo);
            Assert.Equal(aeropuertoId, command.IdAereopuerto);
            Assert.Equal(estado, command.Estado);
            Assert.Equal(matricula, command.Matricula);
        }

        [Fact]
        public void TestConstructor_IsPrivate()
        {
            var command = (RegistrarAeronaveCommand)Activator.CreateInstance(typeof(RegistrarAeronaveCommand), true);
            Assert.Null(command.MantenimientoAeronave);
            Assert.Equal(Guid.Empty, command.IdModelo);
            Assert.Equal(Guid.Empty, command.IdAereopuerto);
            Assert.Equal(0, command.Estado);
            Assert.Null(command.Matricula);
        }
    }
}
