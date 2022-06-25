using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeronave.Application.Dto.Modelo
{
    public class AsientoDto
    {
        public Guid Id { get; set; }
        public int Fila { get;  set; }
        public int Columna { get;  set; }
        public string Area { get;  set; }
    }
}
