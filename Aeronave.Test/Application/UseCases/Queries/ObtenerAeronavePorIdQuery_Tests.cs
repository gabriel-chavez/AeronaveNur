using Aeronave.Application.UseCases.Queries.ObtenerAereonavePorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aeronave.Test.Application.UseCases.Queries
{
    public class ObtenerAeronavePorIdQuery_Tests
    {
        [Fact]
        public void ObtenerAeronavePorIdQuery_DataValid()
        {
            var id = Guid.NewGuid();

            var command = new ObtenerAeronavePorIdQuery(id);

            Assert.Equal(id, command.Id);

        }
        [Fact]
        public void TestConstructor_IsPrivate()
        {
            var command = (ObtenerAeronavePorIdQuery)Activator.CreateInstance(typeof(ObtenerAeronavePorIdQuery), true);
            Assert.Equal(Guid.Empty, command.Id);

        }
    }
}
