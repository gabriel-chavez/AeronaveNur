using Aeronave.Application.Dto.Modelo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeronave.Application.UseCases.Queries.ObtenerModelos
{
    public class ObtenerModelosQuery : IRequest<List<ModeloAeronaveDto>>
    {
        public ObtenerModelosQuery()
        {
        }
    }
}
