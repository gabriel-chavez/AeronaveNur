using ShareKernel.Core;
using ShareKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aeronave.Test.ShareKernel
{
    public record ValueObject_Tests : ValueObject
    {
        [Fact]
        public void Create_Correctly()
        {
            var name = "Prueba nombre";
            CheckRule(new StringNotNullOrEmptyRule(name));
            if (name.Length > 500)
            {
                throw new BussinessRuleValidationException("PersonName can't be more than 500 characters");
            }
           


        }
    }
}
