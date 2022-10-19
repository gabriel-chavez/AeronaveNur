using Aeronave.Application.Dto.Aeronave;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeronave.Application.UseCases.Queries.ObtenerAeronaves
{
    public class ObtenerAeronavesQuery : IRequest<List<AeronaveDto>>
    {
        public ObtenerAeronavesQuery()
        {
        }
    }
}
