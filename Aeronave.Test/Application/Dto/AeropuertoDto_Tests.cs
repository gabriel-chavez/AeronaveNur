using Aeronave.Application.Dto.Aeropuerto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aeronave.Test.Application.Dto
{

    public class AeropuertoDto_Tests
    {
        [Fact]
        public void AeropuertoDto_CheckPropertiesValid()
        {
            var idTest = Guid.NewGuid();
            var nombreTest = "Aeropuerto nuevo";
            var paisTest = "Bolivia";
            var ciudadTest = "La Paz";

            var aeropuertoDto = new AeropuertoDto();

            Assert.Equal(Guid.Empty, aeropuertoDto.Id);
            Assert.Null(aeropuertoDto.Nombre);
            Assert.Null(aeropuertoDto.Pais);
            Assert.Null(aeropuertoDto.Ciudad);
            aeropuertoDto.Id = idTest;
            aeropuertoDto.Nombre = nombreTest;
            aeropuertoDto.Pais = paisTest;
            aeropuertoDto.Ciudad = ciudadTest;

            Assert.Equal(idTest, aeropuertoDto.Id);
            Assert.Equal(nombreTest,aeropuertoDto.Nombre);
            Assert.Equal(paisTest,aeropuertoDto.Pais);
            Assert.Equal(ciudadTest,aeropuertoDto.Ciudad);
        }

    }
}
