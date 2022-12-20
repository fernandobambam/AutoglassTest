using Application.Productos.Queries.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Productos.Queries.GetProductoById
{
    public class GetProductoByIdQuery : IRequest<ProductoDto>
    {
        public int Id { get; set; }
    }
}
