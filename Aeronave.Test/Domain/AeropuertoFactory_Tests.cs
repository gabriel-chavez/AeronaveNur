using Aeronave.Domain.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aeronave.Test.Domain
{
    public class AeropuertoFactory_Tests
    {
        [Fact]
        public void Create_Correctly()
        {
            var nombre = "LPB, Bolivia";
            var pais = "Bolivia";
            var ciudad = "La Paz";
            var factory = new AeropuertoFactory();
            var producto = factory.Crear(nombre, pais, ciudad);

            Assert.NotNull(producto);
            Assert.Equal(nombre, producto.Nombre);
            Assert.Equal(pais, producto.Pais);
            Assert.Equal(ciudad, producto.Ciudad);
         

        }
    }
}
