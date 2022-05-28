using Aeronave.Application.Dto.Aeronave;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeronave.Application.UseCases.Queries.ObtenerAereonavePorId
{
    public  class ObtenerAeronavePorIdQuery : IRequest<AeronaveDto>
    {
        public Guid Id { get; set; }
        public ObtenerAeronavePorIdQuery(Guid id)
        {
            Id = id;
        }
        public ObtenerAeronavePorIdQuery()
        {

        }
    }
}
