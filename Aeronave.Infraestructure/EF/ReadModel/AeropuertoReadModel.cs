using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeronave.Infraestructure.EF.ReadModel
{
    public class AeropuertoReadModel
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
    }
}
