
using Aeronave.Application.Dto.Modelo;
using Aeronave.Application.UseCases.Command.RegistrarModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aeronave.Test.Application.UseCases.Command
{
    public class RegistrarModeloCommand_Tests
    {
        [Fact]
        public void RegistrarModeloCommand_DataValid()
        {
            var modelo = "767-300 ER";
            var marca = "Boeing";
            decimal capacidadCarga = 39790.00m;
            decimal capacidadCargaCombustible = 91380.00m;
            var asiento = new List<AsientoDto>();
            var command = new RegistrarModeloCommand(modelo, marca, capacidadCarga, capacidadCargaCombustible, asiento);

            Assert.Equal(modelo, command.Modelo);
            Assert.Equal(marca, command.Marca);
            Assert.Equal(capacidadCarga, command.CapacidadCarga);
            Assert.Equal(capacidadCargaCombustible, command.CapacidadCargaCombustible);
            Assert.Equal(asiento, command.Asientos);
        }
        [Fact]
        public void TestConstructor_IsPrivate()
        {
            var command = (RegistrarModeloCommand)Activator.CreateInstance(typeof(RegistrarModeloCommand), true);
            Assert.Null(command.Modelo);
            Assert.Null( command.Marca);
            Assert.Equal(0m, command.CapacidadCarga);
            Assert.Equal(0m, command.CapacidadCargaCombustible);
            Assert.Null(command.Asientos);
        }
    }
}
