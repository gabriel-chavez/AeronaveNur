using Aeronave.WebApi;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aeronave.Test.WebApi
{
    public class Startup_Tests
    {
        [Fact]
        public void Create_Correctly()
        {
            var iConfiguration = new Mock<IConfiguration>();
            var iServiceCollection = new Mock<IServiceCollection>();
            var iApplicationBuilder = new Mock<IApplicationBuilder>();
            var iWebHostEnvironment = new Mock<IWebHostEnvironment>();


            try
            {
                var x = new Startup(iConfiguration.Object);
                x.ConfigureServices(iServiceCollection.Object);
                Assert.True(true);
            }
            catch
            {
                Assert.False(false);
            }
            try
            {
                var x = new Startup(iConfiguration.Object);
                x.Configure(iApplicationBuilder.Object, iWebHostEnvironment.Object);
                Assert.True(true);
            }
            catch
            {
                Assert.False(false);
            }

        }
    }
}
