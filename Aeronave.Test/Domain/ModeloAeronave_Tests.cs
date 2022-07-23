using Aeronave.Domain.Model.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aeronave.Test.Domain
{
    public class ModeloAeronave_Tests
    {
        [Fact]
        public void Create_Correctly()
        {


            var modeloAeronave = new ModeloAeronave();
            modeloAeronave.AgregarAsientos(1, 1, "");

            Assert.NotNull(modeloAeronave);



        }
    }
}
