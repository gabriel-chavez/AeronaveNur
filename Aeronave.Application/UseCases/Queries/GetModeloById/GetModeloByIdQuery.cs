using Aeronave.Application.Dto.Modelo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeronave.Application.UseCases.Queries.GetModeloByNombre
{
    public class GetModeloByIdQuery : IRequest<ModeloAeronaveDto>
    {
        public Guid Id { get; set; }
        public GetModeloByIdQuery(Guid id)
        {
            Id = id;
        }
        public GetModeloByIdQuery()
        {

        }
    }
}
