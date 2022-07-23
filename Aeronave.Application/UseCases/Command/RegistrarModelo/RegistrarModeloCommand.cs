using Aeronave.Application.Dto.Modelo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeronave.Application.UseCases.Command.RegistrarModelo
{
    public class RegistrarModeloCommand : IRequest<Guid>
    {
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public decimal CapacidadCarga { get; set; }
        public decimal CapacidadCargaCombustible { get; set; }
        public List<AsientoDto> Asientos { get; set; }

        public RegistrarModeloCommand(string modelo, string marca, decimal capacidadCarga, decimal capacidadCargaCombustible, List<AsientoDto> asientos)
        {
            Modelo = modelo;
            Marca = marca;
            CapacidadCarga = capacidadCarga;
            CapacidadCargaCombustible = capacidadCargaCombustible;
            Asientos = asientos;
        }

        public RegistrarModeloCommand()
        {

        }


    }
}
