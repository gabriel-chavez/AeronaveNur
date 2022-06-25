using Aeronave.Application.Dto.Modelo;
using Aeronave.Application.UseCases.Queries.GetModeloByNombre;
using Aeronave.Domain.Factories;
using Aeronave.Domain.Model.Modelo;
using Aeronave.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Aeronave.Test.Application.UseCases.Handler
{
    public class GetModeloByIdHandler_Tests
    {
        private readonly Mock<IModeloAeronaveRepository> _aeronaveRepository;
        private readonly Mock<ILogger<GetModeloByIdQuery>> _logger;

        private ModeloAeronave modeloAeronaveTest;
        private Guid idTest;

        private string modelo = "767-300 ER";
        private string marca = "Boeing";
        private decimal capacidadCarga = 39790.00m;
        private decimal capacidadCargaCombustible = 91380.00m;

        public GetModeloByIdHandler_Tests()
        {
            _aeronaveRepository = new Mock<IModeloAeronaveRepository>();
            _logger = new Mock<ILogger<GetModeloByIdQuery>>();
            idTest=Guid.NewGuid();

            modeloAeronaveTest = new ModeloAeronaveFactory().Crear(modelo, marca, capacidadCarga, capacidadCargaCombustible);
        }
        [Fact]
        public void GetModeloByIdHandler_HandleCorrectly()
        {
            _aeronaveRepository.Setup(factory => factory.FindByIdAsync(idTest))
                .Returns(Task.FromResult(modeloAeronaveTest));

            var objHandler = new GetModeloByIdHandler(
                _aeronaveRepository.Object,
                _logger.Object                
            );
            var objRequest = new GetModeloByIdQuery(idTest);
            var tcs = new CancellationTokenSource(1000);
            var result = objHandler.Handle(objRequest, tcs.Token);
            Assert.IsType<ModeloAeronaveDto>(result.Result);
            
        }
        [Fact]
        public void CrearProductoHandler_Handle_Fail()
        {
            // Failing by returning null values
            var objHandler = new GetModeloByIdHandler(
                _aeronaveRepository.Object,
                _logger.Object
               
            );
            Guid idTest = Guid.NewGuid();
            var objRequest = new GetModeloByIdQuery(
               idTest
           );
            var tcs = new CancellationTokenSource(1000);
            var result = objHandler.Handle(objRequest, tcs.Token);
            _logger.Verify(mock => mock.Log(
                It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
                It.Is<EventId>(eventId => eventId.Id == 0),
                It.Is<It.IsAnyType>((@object, @type) => @object.ToString() == $"Error al obtener Modelo con id: { idTest }" ),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>())
            , Times.Once);
        }
    }
}
