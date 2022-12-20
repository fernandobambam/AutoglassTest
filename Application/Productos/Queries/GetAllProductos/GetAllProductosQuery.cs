using Application.Productos.Queries.Common;
using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Productos.Queries.GetAllProductos
{
    public class GetAllProductosQuery : IRequest<PagedList<ProductoDto>>
    {
        public string Nombre { get; set; }
        public int? IdProveedor { get; set; }
        public bool? Estado { get; set;  }

        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
