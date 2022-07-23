using Aeronave.Application.UseCases.Command.RegistrarAeropuerto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aeronave.Test.Application.UseCases.Command
{
    public class RegistrarAeropuertoCommand_Tests
    {
        [Fact]
        public void RegistrarAeronaveCommand_DataValid()
        {

            var nombre = "LPB, Bolivia";
            var pais = "Bolivia";
            var ciudad = "La Paz";
            var command = new RegistrarAeropuertoCommand(nombre, pais, ciudad);

            Assert.Equal(nombre, command.Nombre);
            Assert.Equal(pais, command.Pais);
            Assert.Equal(ciudad, command.Ciudad);

        }
        [Fact]
        public void TestConstructor_IsPrivate()
        {
            var command = (RegistrarAeropuertoCommand)Activator.CreateInstance(typeof(RegistrarAeropuertoCommand), true);

            Assert.Null(command.Nombre);
            Assert.Null(command.Pais);
            Assert.Null(command.Ciudad);
        }
    }
}
