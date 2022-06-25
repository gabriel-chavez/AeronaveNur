using Aeronave.Application.Dto.Modelo;
using Aeronave.Application.UseCases.Command.RegistrarModelo;
using Aeronave.Domain.Factories;
using Aeronave.Domain.Model.Modelo;
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
    public class RegistrarModeloHandler_Tests
    {
        private readonly Mock<IModeloAeronaveRepository> _aeronaveRepository;
        private readonly Mock<ILogger<RegistrarModeloHandler>> _logger;
        private readonly Mock<IModeloAeronaveFactory> _aeronaveFactory;
        private readonly Mock<IUnitOfWork> _unitOfWork;

      
        private string modelo = "767-300 ER";
        private string marca = "Boeing";
        private decimal capacidadCarga = 39790.00m;
        private decimal capacidadCargaCombustible = 91380.00m;


        private ModeloAeronave aeronaveTest;
        public RegistrarModeloHandler_Tests()
        {
            _aeronaveRepository = new Mock<IModeloAeronaveRepository>();
            _logger = new Mock<ILogger<RegistrarModeloHandler>>();
            _aeronaveFactory = new Mock<IModeloAeronaveFactory>();
            _unitOfWork = new Mock<IUnitOfWork>();
            aeronaveTest = new ModeloAeronaveFactory().Crear(modelo, marca, capacidadCarga, capacidadCargaCombustible);
        }
        [Fact]
        public void CrearProductoHandler_HandleCorrectly()
        {
            _aeronaveFactory.Setup(factory => factory.Crear(modelo, marca, capacidadCarga, capacidadCargaCombustible))
                .Returns(aeronaveTest);

            var objHandler = new RegistrarModeloHandler(
                _aeronaveRepository.Object,
                _logger.Object,
                _aeronaveFactory.Object,
                _unitOfWork.Object
            );
            var objRequest = new RegistrarModeloCommand(modelo, marca, capacidadCarga, capacidadCargaCombustible, null);
            var tcs = new CancellationTokenSource(1000);
            var result = objHandler.Handle(objRequest, tcs.Token);
            Assert.IsType<Guid>(result.Result);
            var domainEventList = (List<DomainEvent>)aeronaveTest.DomainEvents;
            //Assert.Single(domainEventList);
            //Assert.IsType<AeronaveCreada>(domainEventList[0]);
        }
        [Fact]
        public void CrearProductoHandler_Handle_Fail()
        {
            // Failing by returning null values
            var objHandler = new RegistrarModeloHandler(
                _aeronaveRepository.Object,
                _logger.Object,
                _aeronaveFactory.Object,
                _unitOfWork.Object
            );
            var asientos = new List<AsientoDto>();
            asientos.Add(new AsientoDto() { Area = "", Fila = 1, Columna = 1 });
            asientos.Add(new AsientoDto() { Area = "", Fila = 1, Columna = 1 });
            asientos.Add(new AsientoDto() { Area = "", Fila = 1, Columna = 1 });

            var objRequest = new RegistrarModeloCommand(
               modelo, marca, capacidadCarga, capacidadCargaCombustible, asientos
           );
            var tcs = new CancellationTokenSource(1000);
            var result = objHandler.Handle(objRequest, tcs.Token);
            _logger.Verify(mock => mock.Log(
                It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
                It.Is<EventId>(eventId => eventId.Id == 0),
                It.Is<It.IsAnyType>((@object, @type) => @object.ToString() == "Error al registrar el Modelo"),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>())
            , Times.Once);
        }
    }
}
