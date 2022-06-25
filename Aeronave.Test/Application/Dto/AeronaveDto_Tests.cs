
using Aeronave.Application.Dto.Aeronave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aeronave.Test.Application.Dto
{
    public class AeronaveDto_Tests
    {
        [Fact]
        public void AeronaveDto_CheckPropiertiesValid()
        {
            var idTest = Guid.NewGuid();
            var modeloAeronaveIdTest = Guid.NewGuid();
            var aereopuertoEstacionamientoIdTest = Guid.NewGuid();
            var estadoTest = 0;
            var matriculaTest = "CP-1128";
            var mantenimientoTest = ObtenerDetalleManenimiento();

            var objPedido = new AeronaveDto();
            Assert.Equal(Guid.Empty, objPedido.Id);
            Assert.Equal(Guid.Empty, objPedido.ModeloAeronaveId);
            Assert.Equal(Guid.Empty, objPedido.AereopuertoEstacionamientoId);
            Assert.Equal(0, objPedido.Estado);
            Assert.Null(objPedido.Matricula);
            Assert.Empty(objPedido.MantenimientoAeronave);
            objPedido.Id = idTest;
            objPedido.ModeloAeronaveId = modeloAeronaveIdTest;
            objPedido.AereopuertoEstacionamientoId = aereopuertoEstacionamientoIdTest;
            objPedido.Estado = estadoTest;
            objPedido.Matricula = matriculaTest;
            objPedido.MantenimientoAeronave = mantenimientoTest;
            Assert.Equal(idTest, objPedido.Id);
            Assert.Equal(modeloAeronaveIdTest, objPedido.ModeloAeronaveId);
            Assert.Equal(aereopuertoEstacionamientoIdTest, objPedido.AereopuertoEstacionamientoId);
            Assert.Equal(estadoTest, objPedido.Estado);
            Assert.Equal(matriculaTest,objPedido.Matricula);
            Assert.Equal(mantenimientoTest,objPedido.MantenimientoAeronave);

        }

        private List<MantenimientoDto> ObtenerDetalleManenimiento()
        {
            return new List<MantenimientoDto>()
            {
                new()
                {
                    FechaInicio=DateTime.Now,
                    FechaFin=DateTime.Now,
                    Observaciones="Mantenimiento no asignado",
                }
            };
        }
    }
}
