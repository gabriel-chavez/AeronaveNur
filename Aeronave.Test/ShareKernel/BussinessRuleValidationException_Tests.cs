using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aeronave.Test.ShareKernel
{
    public class BussinessRuleValidationException_Tests
    {
        [Fact]
        public void Create_Correctly()
        {
            var prueba = "Prueba Excepcion";
            var bussinessRuleValidationException = new BussinessRuleValidationException(prueba);
            Assert.Equal(prueba, bussinessRuleValidationException.Message);
        }
    }
}
