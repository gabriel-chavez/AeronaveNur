using Aeronave.Domain.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aeronave.Test.Domain
{
    public class AeronaveFactory_Tests
    {
        [Fact]
        public void Create_Correctly()
        {
            var modeloId = new Guid("3FA85F64-5717-4562-B3FC-2C963F66AFA6");
            var aeropuertoId = new Guid("3FA85F64-5717-4562-B3FC-2C963F66AFA6");
            var estado = 0;
            var matricula = "CP-1128";
            var factory = new AeronaveFactory();
            var producto = factory.Crear(modeloId, aeropuertoId, estado, matricula);
            var aeronave = new Aeronave.Domain.Model.Aeronaves.Aeronave(modeloId, aeropuertoId, estado, matricula);
            var fecha = DateTime.Now;

            aeronave.AgregarItem(fecha, fecha, "");
            Assert.NotNull(aeronave);
            Assert.NotNull(producto);
            Assert.Equal(modeloId, producto.ModeloAeronaveId);
            Assert.Equal(aeropuertoId, producto.AereopuertoId);
            Assert.Equal(estado, producto.Estado);
            Assert.Equal(matricula, producto.Matricula);

        }
    }
}
