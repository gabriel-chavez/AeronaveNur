using Aeronave.Application.Dto.Aeropuerto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeronave.Application.UseCases.Queries.ObtenerAeropuertos
{
    public class ObtenerAeropuertosQuery : IRequest<List<AeropuertoDto>>
    {
        public ObtenerAeropuertosQuery()
        {
        }
    }
}
