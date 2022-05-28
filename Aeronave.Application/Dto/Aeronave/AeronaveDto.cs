using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeronave.Application.Dto.Aeronave
{
    public class AeronaveDto
    {
        public Guid Id { get; set; }
        public Guid IdModelo { get;  set; }
        public Guid IdAereopuertoEstacionamiento { get;  set; }
        public int Estado { get;  set; }
        public string Matricula { get; set; }
        public List<MantenimientoDto> MantenimientoAeronave;
        public AeronaveDto()
        {
            MantenimientoAeronave = new List<MantenimientoDto>();
        }
    }
}
