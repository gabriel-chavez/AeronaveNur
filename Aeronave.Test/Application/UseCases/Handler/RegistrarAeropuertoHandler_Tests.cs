using Aeronave.Application.UseCases.Command.RegistrarAeropuerto;
using Aeronave.Domain.Factories;
using Aeronave.Domain.Model.Aeropuertos;
using Aeronave.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Aeronave.Test.Application.UseCases.Handler
{
    public class RegistrarAeropuertoHandler_Tests
    {
        private readonly Mock<IAeropuertoRepository> _aeronaveRepository;
        private readonly Mock<ILogger<RegistrarAeropuertoHandler>> _logger;
        private readonly Mock<IAeropuertoFactory> _aeronaveFactory;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        private string nombre = "LPB, Bolivia";
        private string pais = "Bolivia";
        private string ciudad = "La Paz";
        private Aeropuerto aeronaveTest;
        public RegistrarAeropuertoHandler_Tests()
        {
            _aeronaveRepository = new Mock<IAeropuertoRepository>();
            _logger = new Mock<ILogger<RegistrarAeropuertoHandler>>();
            _aeronaveFactory = new Mock<IAeropuertoFactory>();
            _unitOfWork = new Mock<IUnitOfWork>();
            aeronaveTest = new AeropuertoFactory().Crear(nombre, pais, ciudad);
        }
        [Fact]
        public void RegistrarAeropuertoHandler_HandleCorrectly()
        {
            _aeronaveFactory.Setup(factory => factory.Crear(nombre, pais, ciudad))
                .Returns(aeronaveTest);

            var objHandler = new RegistrarAeropuertoHandler(
                _aeronaveRepository.Object,
                _logger.Object,
                _aeronaveFactory.Object,
                _unitOfWork.Object
            );
            var objRequest = new RegistrarAeropuertoCommand(nombre, pais, ciudad);
            var tcs = new CancellationTokenSource(1000);
            var result = objHandler.Handle(objRequest, tcs.Token);
            Assert.IsType<Guid>(result.Result);
            //var domainEventList = (List<DomainEvent>)aeronaveTest.DomainEvents;
            //Assert.Single(domainEventList);
            //Assert.IsType<AeronaveCreada>(domainEventList[0]);
        }
        [Fact]
        public void RegistrarAeropuertoHandler_Handle_Fail()
        {
            // Failing by returning null values
            var objHandler = new RegistrarAeropuertoHandler(
                _aeronaveRepository.Object,
                _logger.Object,
                _aeronaveFactory.Object,
                _unitOfWork.Object
            );
           
            var objRequest = new RegistrarAeropuertoCommand(
              nombre, pais, ciudad
           );
            var tcs = new CancellationTokenSource(1000);
            var result = objHandler.Handle(objRequest, tcs.Token);
            _logger.Verify(mock => mock.Log(
                It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
                It.Is<EventId>(eventId => eventId.Id == 0),
                It.Is<It.IsAnyType>((@object, @type) => @object.ToString() == "Error al crear el aeropuerto"),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>())
            , Times.Once);
        }
    }
}
