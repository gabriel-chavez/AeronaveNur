using Aeronave.Application.Dto.Aeronave;
using Aeronave.Application.UseCases.Command.RegistrarAeronave;
using Aeronave.Domain.Event;
using Aeronave.Domain.Factories;
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
    public class RegistrarAeronaveHandler_Tests
    {
        private readonly Mock<IAeronaveRepository> _aeronaveRepository;
        private readonly Mock<ILogger<RegistrarAeronaveHandler>> _logger;
        private readonly Mock<IAeronaveFactory> _aeronaveFactory;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        private Guid modeloId= new Guid("3FA85F64-5717-4562-B3FC-2C963F66AFA6");
        private Guid aeropuertoId = new Guid("3FA85F64-5717-4562-B3FC-2C963F66AFA6");
        private int estado = 0;
        private string matricula = "CP-1128";
        private Aeronave.Domain.Model.Aeronaves.Aeronave aeronaveTest;
        public RegistrarAeronaveHandler_Tests()
        {
            _aeronaveRepository = new Mock<IAeronaveRepository>(); 
            _logger = new Mock<ILogger<RegistrarAeronaveHandler>>();
               _aeronaveFactory = new Mock<IAeronaveFactory>();
            _unitOfWork = new Mock<IUnitOfWork>();
            aeronaveTest = new AeronaveFactory().Crear(modeloId, aeropuertoId, estado, matricula);
        }
        [Fact]
        public void RegistrarAeronaveHandler_HandleCorrectly()
        {
            _aeronaveFactory.Setup(factory => factory.Crear(modeloId, aeropuertoId, estado, matricula))
                .Returns(aeronaveTest);

            var objHandler = new RegistrarAeronaveHandler(
                _aeronaveRepository.Object,
                _logger.Object,
                _aeronaveFactory.Object,
                _unitOfWork.Object
            );
            var objRequest = new RegistrarAeronaveCommand(new List<MantenimientoDto>(), modeloId, aeropuertoId, estado, matricula);
            var tcs = new CancellationTokenSource(1000);
            var result = objHandler.Handle(objRequest, tcs.Token);
            Assert.IsType<Guid>(result.Result);
            var domainEventList = (List<DomainEvent>)aeronaveTest.DomainEvents;
            Assert.Single(domainEventList);
            Assert.IsType<AeronaveCreada>(domainEventList[0]);
        }
        [Fact]
        public void RegistrarAeronaveHandler_Handle_Fail()
        {
            // Failing by returning null values
            var objHandler = new RegistrarAeronaveHandler(
                _aeronaveRepository.Object,
                _logger.Object,
                _aeronaveFactory.Object,
                _unitOfWork.Object
            );
            var mantenimiento = new List<MantenimientoDto>();
            mantenimiento.Add(new MantenimientoDto() { FechaFin = DateTime.Now, FechaInicio = DateTime.Now, Observaciones = "prueba" });
            var objRequest = new RegistrarAeronaveCommand(
               mantenimiento, modeloId, aeropuertoId, estado, matricula
           );
            var tcs = new CancellationTokenSource(1000);
            var result = objHandler.Handle(objRequest, tcs.Token);
            _logger.Verify(mock => mock.Log(
                It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
                It.Is<EventId>(eventId => eventId.Id == 0),
                It.Is<It.IsAnyType>((@object, @type) => @object.ToString() == "Error al crear la aeronave"),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>())
            , Times.Once);
        }
        [Fact]
        public void RegistrarAeronaveHandler_Handle_Fail2()
        {
            // Failing by returning null values
            var objHandler = new RegistrarAeronaveHandler(
                _aeronaveRepository.Object,
                _logger.Object,
                _aeronaveFactory.Object,
                _unitOfWork.Object
            );

            var objRequest = new RegistrarAeronaveCommand(
               null, modeloId, aeropuertoId, estado, matricula
           );
            var tcs = new CancellationTokenSource(1000);
            var result = objHandler.Handle(objRequest, tcs.Token);
            _logger.Verify(mock => mock.Log(
                It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
                It.Is<EventId>(eventId => eventId.Id == 0),
                It.Is<It.IsAnyType>((@object, @type) => @object.ToString() == "Error al crear la aeronave"),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>())
            , Times.Once);
        }
    }
}
