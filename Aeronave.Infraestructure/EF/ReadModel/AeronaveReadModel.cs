using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeronave.Infraestructure.EF.ReadModel
{
    public  class AeronaveReadModel
    {
        public Guid Id { get; set; }
       
        public int Estado { get;  set; }
        public string Matricula { get; set; }
        public List<MantenimientoReadModel> MantenimientoAeronave { get; set; }
        public ModeloAeronaveReadModel ModeloAeronave { get; set; }
        public AeropuertoReadModel Aereopuerto { get; set; }


    }
}
