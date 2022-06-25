using Aeronave.Domain.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aeronave.Test.Domain
{
    public class AsientoAgregado_Tests
    {
        [Fact]
        public void Create_Correctly()
        {
            var fila = 1;
            var columna = 1;
            var area = "Economica";

            var asiento = new AsientoAgregado(fila, columna, area);

            Assert.NotNull(asiento);
            Assert.Equal(fila, asiento.Fila);
            Assert.Equal(columna, asiento.Columna);
            Assert.Equal(area, asiento.Area);
            

        }
    }
}
