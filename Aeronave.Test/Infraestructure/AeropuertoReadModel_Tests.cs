using Aeronave.Infraestructure.EF.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aeronave.Test.Infraestructure
{
    public class AeropuertoReadModel_Tests
    {
        [Fact]
        public void Create_Correctly()
        {
            var id = Guid.NewGuid();
            var nombre = "LPB, Bolivia";
            var pais = "Bolivia";
            var ciudad = "La Paz";


            var aeronaveReadModel = new AeropuertoReadModel();
            aeronaveReadModel.Id = id;
            aeronaveReadModel.Nombre = nombre;
            aeronaveReadModel.Pais = pais;
            aeronaveReadModel.Ciudad = ciudad;


            Assert.Equal(id, aeronaveReadModel.Id);
            Assert.Equal(nombre, aeronaveReadModel.Nombre);
            Assert.Equal(pais, aeronaveReadModel.Pais);
            Assert.Equal(ciudad, aeronaveReadModel.Ciudad);
            


        }
    }
}
