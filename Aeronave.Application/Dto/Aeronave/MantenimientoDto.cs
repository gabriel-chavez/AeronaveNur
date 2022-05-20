using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeronave.Application.Dto.Aeronave
{
    public class MantenimientoDto
    {
        public DateTime FechaInicio { get;  set; }

        public DateTime FechaFin { get;  set; }
        public string Observaciones { get;  set; }
    }
}
