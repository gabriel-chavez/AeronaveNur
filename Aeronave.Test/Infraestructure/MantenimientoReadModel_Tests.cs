using Aeronave.Infraestructure.EF.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aeronave.Test.Infraestructure
{
    public  class MantenimientoReadModel_Tests
    {
        [Fact]
        public void Create_Correctly()
        {
            var id = Guid.NewGuid();
            var fecha = DateTime.Now;
            var observaciones = "ninguna";
        

            var mantenimientoReadModel = new MantenimientoReadModel();
            mantenimientoReadModel.Id = id;
            mantenimientoReadModel.FechaFin = fecha;
            mantenimientoReadModel.FechaInicio= fecha;
            mantenimientoReadModel.Observaciones = observaciones;
            mantenimientoReadModel.Aeronave = new AeronaveReadModel();

            Assert.Equal(id, mantenimientoReadModel.Id);
            Assert.Equal(fecha, mantenimientoReadModel.FechaFin);
            Assert.Equal(fecha, mantenimientoReadModel.FechaInicio);
            Assert.Equal(observaciones, mantenimientoReadModel.Observaciones);


        }
    }
}
