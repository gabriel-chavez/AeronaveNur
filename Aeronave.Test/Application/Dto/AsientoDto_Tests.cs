using Aeronave.Application.Dto.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aeronave.Test.Application.Dto
{
    public class AsientoDto_Tests
    {
        [Fact]
        public void AsientoDto_CheckPropertiesValid()
        {
            var id = Guid.NewGuid();
            var fila = 1;
            var columna = 2;
            var area = "Economica";

            var asientoDto = new AsientoDto();

            Assert.Equal(Guid.Empty, asientoDto.Id);
            Assert.Equal(0, asientoDto.Fila);
            Assert.Equal(0, asientoDto.Columna);
            Assert.Null(asientoDto.Area);


            asientoDto.Id = id;
            asientoDto.Fila = fila;
            asientoDto.Columna = columna;
            asientoDto.Area = area;

            Assert.Equal(id, asientoDto.Id);
            Assert.Equal(fila, asientoDto.Fila);
            Assert.Equal(columna, asientoDto.Columna);
            Assert.Equal(area, asientoDto.Area);





        }
    }
}