using Aeronave.Infraestructure.EF.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aeronave.Test.Infraestructure
{
    public class ModeloAeronaveReadModel_Test
    {
        [Fact]
        public void Create_Correctly()
        {
            var id = Guid.NewGuid();
            var modelo = "767-300 ER";
            var marca = "Boeing";
            decimal capacidadCarga = 39790.00m;
            decimal capacidadCargaCombustible = 91380.00m;



            var modeloAeronaveReadModel = new ModeloAeronaveReadModel();
            modeloAeronaveReadModel.Id = id;
            modeloAeronaveReadModel.Modelo = modelo;
            modeloAeronaveReadModel.Marca = marca;
            modeloAeronaveReadModel.CapacidadCarga = capacidadCarga;
            modeloAeronaveReadModel.CapacidadCargaCombustible = capacidadCargaCombustible;
            modeloAeronaveReadModel.Asientos = new List<AsientoReadModel>();

            Assert.Equal(id, modeloAeronaveReadModel.Id);
            Assert.Equal(modelo, modeloAeronaveReadModel.Modelo);
            Assert.Equal(marca, modeloAeronaveReadModel.Marca);
            Assert.Equal(capacidadCarga, modeloAeronaveReadModel.CapacidadCarga);
            Assert.Equal(capacidadCargaCombustible, modeloAeronaveReadModel.CapacidadCargaCombustible);
            Assert.Equal(new List<AsientoReadModel>(), modeloAeronaveReadModel.Asientos);


        }
    }
}
