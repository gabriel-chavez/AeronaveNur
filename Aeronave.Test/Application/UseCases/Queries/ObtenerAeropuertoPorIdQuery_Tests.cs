using Aeronave.Application.UseCases.Queries.ObtenerAeropuertoPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aeronave.Test.Application.UseCases.Queries
{
    public class ObtenerAeropuertoPorIdQuery_Tests
    {
        [Fact]
        public void ObtenerAeropuertoPorIdQuery_DataValid()
        {
            var id = Guid.NewGuid();

            var command = new ObtenerAeropuertoPorIdQuery(id);

            Assert.Equal(id, command.Id);

        }
        [Fact]
        public void TestConstructor_IsPrivate()
        {
            var command = (ObtenerAeropuertoPorIdQuery)Activator.CreateInstance(typeof(ObtenerAeropuertoPorIdQuery), true);
            Assert.Equal(Guid.Empty, command.Id);

        }
    }
}
