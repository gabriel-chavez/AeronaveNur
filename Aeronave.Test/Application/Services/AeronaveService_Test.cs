using Aeronave.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aeronave.Test.Application.Services
{
    public class AeronaveService_Test
    {
        [Theory]
        [InlineData("CP-1128", true)]
        [InlineData("CP-1328", false)]
        [InlineData("CP-2328", false)]
        [InlineData("CP-1320", false)]
        [InlineData("CP-3128", false)]
        [InlineData("CP-5328", false)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public async void AeronaveService_CheckValidData(string expectedMatricula, bool isEqual)
        {
            var aeronaveService = new AeronaveService();
            string nroPedido = await aeronaveService.GenerarMatriculaAleatoria();
            if (isEqual)
            {
                Assert.Equal(expectedMatricula, nroPedido);
            }
            else
            {
                Assert.NotEqual(expectedMatricula, nroPedido);
            }
        }

    }
}
