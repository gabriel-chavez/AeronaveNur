using Aeronave.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aeronave.Test.WebApi
{
    public  class Program_Tests
    {
        [Fact]
        public void Create_Correctly()
        {

            string[] arg = new String[1];
            try
            {
                Program.Main(arg);
                Assert.True(true);
            }
            catch
            {
                Assert.False(false);
            }

           
        }
    }
}
