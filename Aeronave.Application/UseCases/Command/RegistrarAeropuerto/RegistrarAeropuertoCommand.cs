using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeronave.Application.UseCases.Command.RegistrarAeropuerto
{
    public class RegistrarAeropuertoCommand: IRequest<Guid>
    {
        public string Nombre { get;  set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }

        public RegistrarAeropuertoCommand(string nombre, string pais, string ciudad)
        {
            Nombre = nombre;
            Pais = pais;
            Ciudad = ciudad;
        }
        public RegistrarAeropuertoCommand()
        {

        }
    }
}
