using Aeronave.Domain.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aeronave.Test.Domain
{
    public class ModeloAeronaveFactory_Tests
    {
        [Fact]
        public void Create_Correctly()
        {
            var modelo = "767-300 ER";
            var marca = "Boeing";
            decimal capacidadCarga = 39790.00m;
            decimal capacidadCargaCombustible = 91380.00m;
            var factory = new ModeloAeronaveFactory();
            var producto = factory.Crear(modelo, marca, capacidadCarga, capacidadCargaCombustible);

            Assert.NotNull(producto);
            Assert.Equal(modelo, producto.Modelo);
            Assert.Equal(marca, producto.Marca);
            Assert.Equal(capacidadCarga, producto.CapacidadCarga);
            Assert.Equal(capacidadCargaCombustible, producto.CapacidadCargaCombustible);


        }
    }
}
