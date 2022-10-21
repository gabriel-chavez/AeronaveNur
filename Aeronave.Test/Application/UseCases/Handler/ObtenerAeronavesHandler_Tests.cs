using Aeronave.Application.Dto.Aeronave;
using Aeronave.Application.UseCases.Queries.ObtenerAeronaves;
using Aeronave.Domain.Factories;
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
    public class ObtenerAeronavesHandler_Tests
    {

        private readonly Mock<IAeronaveRepository> _aeronaveRepository;
        private readonly Mock<ILogger<ObtenerAeronavesQuery>> _logger;

        private List<Aeronave.Domain.Model.Aeronaves.Aeronave> aeronaveTest = new List<Aeronave.Domain.Model.Aeronaves.Aeronave>();


        private Guid modeloId = new Guid("3FA85F64-5717-4562-B3FC-2C963F66AFA6");
        private Guid aeropuertoId = new Guid("3FA85F64-5717-4562-B3FC-2C963F66AFA6");
        private int estado = 0;
        private string matricula = "CP-1128";

        public ObtenerAeronavesHandler_Tests()
        {
            _aeronaveRepository = new Mock<IAeronaveRepository>();
            _logger = new Mock<ILogger<ObtenerAeronavesQuery>>();
            var x = new AeronaveFactory().Crear(modeloId, aeropuertoId, estado, matricula);

            aeronaveTest.Add(x);
            //  aeronaveTest.AgregarItem(DateTime.Now, DateTime.Now, "");
        }
        public Mock<IAeronaveRepository> AeronaveRepository => _aeronaveRepository;

        // [Fact]
        //public void GetModeloHandler_HandleCorrectly()
        //{
        //    AeronaveRepository.Setup(factory => factory.RetornarAeronaves())
        //        .Returns(Task.FromResult(aeronaveTest));

        //    var objHandler = new ObtenerAeronavesHandler(
        //        AeronaveRepository.Object,
        //        _logger.Object
        //    );
        //    var objRequest = new ObtenerAeronavesQuery();
        //    var tcs = new CancellationTokenSource(1000);
        //    var result = objHandler.Handle(objRequest, tcs.Token);
        //    Assert.IsType<AeronaveDto>(result.Result);

        //}

        //[Fact]
        //public void CrearProductoHandler_Handle_Fail()
        //{
        //    // Failing by returning null values
        //    var objHandler = new ObtenerAeronavesHandler(
        //        _aeronaveRepository.Object,
        //        _logger.Object

        //    );
        //    Guid idTest = Guid.NewGuid();
        //    var objRequest = new ObtenerAeronavesQuery();
        //    var tcs = new CancellationTokenSource(1000);
        //    var result = objHandler.Handle(objRequest, tcs.Token);
        //    _logger.Verify(mock => mock.Log(
        //        It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
        //        It.Is<EventId>(eventId => eventId.Id == 0),
        //        It.Is<It.IsAnyType>((@object, @type) => @object.ToString() == $"Error al obtener Aeronave con id: { idTest }"),
        //        It.IsAny<Exception>(),
        //        It.IsAny<Func<It.IsAnyType, Exception, string>>())
        //    , Times.Once);
        //}


    }
}
