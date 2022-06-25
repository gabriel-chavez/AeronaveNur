using Aeronave.Domain.Model.Modelo;
using Aeronave.Infraestructure.EF.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aeronave.Test.Infraestructure
{
    public class AsientoReadModel_Tests
    {
        [Fact]
        public void Create_Correctly()
        {
            var id = Guid.NewGuid();
            var fila = 1;
            var columna = 1;
            var area = "ninguna";

            var asientoReadModel = new AsientoReadModel();
            asientoReadModel.Id = id;
            asientoReadModel.Fila=fila;
            asientoReadModel.Columna=columna;
            asientoReadModel.Area=area;
            asientoReadModel.ModeloAeronave = new ModeloAeronaveReadModel();


            Assert.Equal(id, asientoReadModel.Id);
            Assert.Equal(fila, asientoReadModel.Fila);
            Assert.Equal(columna, asientoReadModel.Columna);
            Assert.Equal(area, asientoReadModel.Area);


        }
    }
}
