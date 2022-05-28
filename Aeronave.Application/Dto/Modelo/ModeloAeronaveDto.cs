using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeronave.Application.Dto.Modelo
{
    public  class ModeloAeronaveDto
    {
        public Guid Id { get; set; }
        public string Modelo { get;  set; }
        public string Marca { get;  set; }
        public decimal CapacidadCarga { get;  set; }
        public decimal CapacidadCargaCombustible { get; set; }
        public List<AsientoDto> Asientos { get; set; }
    }
}
