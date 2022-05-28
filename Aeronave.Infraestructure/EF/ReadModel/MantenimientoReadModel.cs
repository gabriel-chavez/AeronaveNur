using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeronave.Infraestructure.EF.ReadModel
{
    public class MantenimientoReadModel
    {
        public Guid Id { get; set; }
        public DateTime FechaInicio { get;  set; }

        public DateTime FechaFin { get;  set; }
        public string Observaciones { get;  set; }
        public AeronaveReadModel Aeronave { get; set; }
    }
}
