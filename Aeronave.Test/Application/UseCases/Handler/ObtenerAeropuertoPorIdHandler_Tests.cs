using Aeronave.Application.Dto.Aeropuerto;
using Aeronave.Application.UseCases.Queries.ObtenerAeropuertoPorId;
using Aeronave.Domain.Factories;
using Aeronave.Domain.Model.Aeropuertos;
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
    public class ObtenerAeropuertoPorIdHandler_Tests
    {
        private readonly Mock<IAeropuertoRepository> _aeronaveRepository;
        private readonly Mock<ILogger<ObtenerAeropuertoPorIdQuery>> _logger;

        
        private Guid idTest;
        private string nombre = "LPB, Bolivia";
        private string pais = "Bolivia";
        private string ciudad = "La Paz";
        private Aeropuerto aeronaveTest;

        public ObtenerAeropuertoPorIdHandler_Tests()
        {
            _aeronaveRepository = new Mock<IAeropuertoRepository>();
            _logger = new Mock<ILogger<ObtenerAeropuertoPorIdQuery>>();
            idTest = Guid.NewGuid();

            aeronaveTest = new AeropuertoFactory().Crear(nombre, pais, ciudad);
        }

        public Mock<IAeropuertoRepository> AeronaveRepository => _aeronaveRepository;

        [Fact]
        public void GetModeloByIdHandler_HandleCorrectly()
        {
            AeronaveRepository.Setup(factory => factory.FindByIdAsync(idTest))
                .Returns(Task.FromResult(aeronaveTest));

            var objHandler = new ObtenerAeropuertoPorIdHandler(
                AeronaveRepository.Object,
                _logger.Object
            );
            var objRequest = new ObtenerAeropuertoPorIdQuery(idTest);
            var tcs = new CancellationTokenSource(1000);
            var result = objHandler.Handle(objRequest, tcs.Token);
            Assert.IsType<AeropuertoDto>(result.Result);
        }
        [Fact]
        public void CrearProductoHandler_Handle_Fail()
        {
            // Failing by returning null values
            var objHandler = new ObtenerAeropuertoPorIdHandler(
                _aeronaveRepository.Object,
                _logger.Object

            );
            Guid idTest = Guid.NewGuid();
            var objRequest = new ObtenerAeropuertoPorIdQuery(
               idTest
           );
            var tcs = new CancellationTokenSource(1000);
            var result = objHandler.Handle(objRequest, tcs.Token);
            _logger.Verify(mock => mock.Log(
                It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
                It.Is<EventId>(eventId => eventId.Id == 0),
                It.Is<It.IsAnyType>((@object, @type) => @object.ToString() == $"Error al obtener Aueropuerto con id: { idTest }"),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>())
            , Times.Once);
        }
    }
}
