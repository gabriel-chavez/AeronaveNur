using Aeronave.Application.Dto.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aeronave.Test.Application.Dto
{
    public class ModeloAeronaveDto_Tests
    {

        [Fact]
        public void ModeloAeronaveDto_CheckPropertiesValid()
        {
            var id = Guid.NewGuid();
            var modelo = "767-300 ER";
            var marca = "Boeing";
            var capacidadCarga = 0;
            var capacidadCargaCombustible = 0;

            var modeloAeronaveDto = new ModeloAeronaveDto();


            Assert.Equal(Guid.Empty, modeloAeronaveDto.Id);
            Assert.Null(modeloAeronaveDto.Modelo);
            Assert.Null(modeloAeronaveDto.Marca);
            Assert.Equal(0, modeloAeronaveDto.CapacidadCarga);
            Assert.Equal(0, modeloAeronaveDto.CapacidadCargaCombustible);

            modeloAeronaveDto.Id = id;
            modeloAeronaveDto.Modelo = modelo;
            modeloAeronaveDto.Marca = marca;
            modeloAeronaveDto.CapacidadCarga = capacidadCarga;
            modeloAeronaveDto.CapacidadCargaCombustible = capacidadCargaCombustible;

            Assert.Equal(id, modeloAeronaveDto.Id);
            Assert.Equal(modelo, modeloAeronaveDto.Modelo);
            Assert.Equal(marca, modeloAeronaveDto.Marca);
            Assert.Equal(capacidadCarga, modeloAeronaveDto.CapacidadCarga);
            Assert.Equal(capacidadCargaCombustible, modeloAeronaveDto.CapacidadCargaCombustible);




        }




    }
}
