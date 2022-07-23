using Aeronave.Application.Dto.Aeronave;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeronave.Application.UseCases.Command.RegistrarAeronave
{
    public class RegistrarAeronaveCommand : IRequest<Guid>
    {
        public Guid IdModelo { get; set; }
        public Guid IdAereopuerto { get; set; }
        public int Estado { get; set; }
        public string Matricula { get; set; }
        public List<MantenimientoDto> MantenimientoAeronave;

        public RegistrarAeronaveCommand(List<MantenimientoDto> mantenimientoAeronave, Guid idModelo, Guid idAereopuerto, int estado, string matricula)
        {
            MantenimientoAeronave = mantenimientoAeronave;
            IdModelo = idModelo;
            IdAereopuerto = idAereopuerto;
            Estado = estado;
            Matricula = matricula;
        }
        public RegistrarAeronaveCommand()
        {

        }
    }
}
