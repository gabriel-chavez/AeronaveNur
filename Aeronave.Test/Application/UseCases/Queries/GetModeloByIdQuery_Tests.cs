using Aeronave.Application.UseCases.Queries.GetModeloByNombre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aeronave.Test.Application.UseCases.Queries
{
    public class GetModeloByIdQuery_Tests
    {
        [Fact]
        public void GetModeloByIdQuery_DataValid()
        {
            var id = Guid.NewGuid();
            
            var command = new GetModeloByIdQuery(id);

            Assert.Equal(id, command.Id);
            
        }
        [Fact]
        public void TestConstructor_IsPrivate()
        {            
            var command = (GetModeloByIdQuery)Activator.CreateInstance(typeof(GetModeloByIdQuery), true);
            Assert.Equal(Guid.Empty, command.Id);
            
        }
    }
}
