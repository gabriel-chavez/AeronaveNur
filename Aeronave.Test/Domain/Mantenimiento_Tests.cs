using Aeronave.Domain.Model.Aeronaves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aeronave.Test.Domain
{
    public class Mantenimiento_Tests
    {
        [Fact]
        public void Create_Correctly()
        {
            var fechaInicio = DateTime.Now;
            var fechaFin = DateTime.Now;
            var observaciones = "ninguna";

            var mantenimiento = new Mantenimiento(fechaInicio, fechaFin, observaciones);

            Assert.NotNull(mantenimiento);
            Assert.Equal(fechaInicio, mantenimiento.FechaInicio);
            Assert.Equal(fechaFin, mantenimiento.FechaFin);
            Assert.Equal(observaciones, mantenimiento.Observaciones);


        }
    }
}
