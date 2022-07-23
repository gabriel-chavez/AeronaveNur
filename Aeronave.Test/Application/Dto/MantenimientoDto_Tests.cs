using Aeronave.Application.Dto.Aeronave;
using Aeronave.Application.Dto.Aeropuerto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aeronave.Test.Application.Dto
{
    public class MantenimientoDto_Tests
    {
        [Fact]
        public void AeropuertoDto_CheckPropiertiesValid()
        {
            var id = Guid.NewGuid();
            var fechaInicio = DateTime.Now;
            var fechaFin = DateTime.Now;
            var observaciones = "ninguna";

            var mantenimientoDto = new MantenimientoDto();

            Assert.Equal(Guid.Empty, mantenimientoDto.Id);
            Assert.Equal(DateTime.MinValue.ToString("dd/MM/yyyy"), mantenimientoDto.FechaInicio.ToString("dd/MM/yyyy"));
            Assert.Equal(DateTime.MinValue.ToString("dd/MM/yyyy"), mantenimientoDto.FechaInicio.ToString("dd/MM/yyyy"));
            Assert.Null(mantenimientoDto.Observaciones);

            mantenimientoDto.Id = id;
            mantenimientoDto.FechaInicio = fechaInicio;
            mantenimientoDto.FechaFin = fechaFin;
            mantenimientoDto.Observaciones = observaciones;

            Assert.Equal(id, mantenimientoDto.Id);
            Assert.Equal(fechaInicio, mantenimientoDto.FechaInicio);
            Assert.Equal(fechaFin, mantenimientoDto.FechaFin);
            Assert.Equal(observaciones, mantenimientoDto.Observaciones);





        }


    }
}
