using Application.Common.Interfaces;
using Application.Productos.Queries.Common;
using Application.Productos.Queries.GetProductoById;
using AutoMapper;
using Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Productos.Handlers
{
    public class GetProductoByIdHandler : IRequestHandler<GetProductoByIdQuery, ProductoDto>
    {
        private readonly IAutoglassContext _autoglassContext;
        private readonly IMapper _mapper;

        public GetProductoByIdHandler(IAutoglassContext autoglassContext, IMapper mapper)
        {
            _autoglassContext = autoglassContext;
            _mapper = mapper;
        }

        public Task<ProductoDto> Handle(GetProductoByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = _autoglassContext.Productos.Where(x => x.IdProducto == request.Id).FirstOrDefault();

            if (entity == null)
                throw new NotFoundException("No se encontró producto");

            var productoDto = _mapper.Map<ProductoDto>(entity);

            return Task.FromResult(productoDto); 
        }
    }
}
