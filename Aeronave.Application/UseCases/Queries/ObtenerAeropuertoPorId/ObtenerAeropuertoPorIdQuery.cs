using Aeronave.Application.Dto.Aeropuerto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeronave.Application.UseCases.Queries.ObtenerAeropuertoPorId
{
    public class ObtenerAeropuertoPorIdQuery : IRequest<AeropuertoDto>
    {
        public Guid Id { get; set; }
        public ObtenerAeropuertoPorIdQuery(Guid id)
        {
            Id = id;
        }
        public ObtenerAeropuertoPorIdQuery()
        {

        }
    }
}
