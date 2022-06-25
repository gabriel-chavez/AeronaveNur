using Aeronave.Domain.Model.Aeropuertos;
using Aeronave.Infraestructure.EF.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aeronave.Test.Infraestructure
{
    public class AeronaveReadModel_Tests
    {
        [Fact]
        public void Create_Correctly()
        {
            var id = Guid.NewGuid();
            var estado = 0;
            var matricula = "";
            var mantenimientoAeronave = new List<MantenimientoReadModel>();
            var modeloAeronave = new ModeloAeronaveReadModel();
            var aereopuerto = new AeropuertoReadModel();

            var aeronaveReadModel = new AeronaveReadModel();
            aeronaveReadModel.Id = id;
            aeronaveReadModel.Estado = estado;
            aeronaveReadModel.Matricula = matricula;
            aeronaveReadModel.MantenimientoAeronave = mantenimientoAeronave;
            aeronaveReadModel.ModeloAeronave = modeloAeronave;
            aeronaveReadModel.Aereopuerto = aereopuerto;

            Assert.Equal(id, aeronaveReadModel.Id);
            Assert.Equal(estado, aeronaveReadModel.Estado);
            Assert.Equal(matricula, aeronaveReadModel.Matricula);
            Assert.Equal(mantenimientoAeronave, aeronaveReadModel.MantenimientoAeronave);
            Assert.Equal(modeloAeronave, aeronaveReadModel.ModeloAeronave);
            Assert.Equal(aereopuerto, aeronaveReadModel.Aereopuerto);


        }
    }
}
