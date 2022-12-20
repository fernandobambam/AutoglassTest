using Application.Common.Interfaces;
using Application.Productos.Queries.Common;
using Application.Productos.Queries.GetAllProductos;
using AutoMapper;
using Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Productos.Handlers
{
    public class GetAllProductosHandler : IRequestHandler<GetAllProductosQuery, PagedList<ProductoDto>>
    {
        private readonly IAutoglassContext _autoglassContext;
        private readonly IMapper _mapper;
        private readonly FiltersOptions _paginationOptions;


        public GetAllProductosHandler(IAutoglassContext autoglassContext, IMapper mapper, IOptions<FiltersOptions> options)
        {
            _autoglassContext = autoglassContext; 
            _mapper = mapper;
            _paginationOptions = options.Value; 
        }

        public Task<PagedList<ProductoDto>> Handle(GetAllProductosQuery request, CancellationToken cancellationToken)
        {
            request.PageNumber = request.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : request.PageNumber;
            request.PageSize = request.PageSize == 0 ? _paginationOptions.DefaultPageSize : request.PageSize;
            request.Estado = request.Estado == null ? true : request.Estado;

            var productos = _autoglassContext.Productos.AsQueryable();

            if(request.Nombre != null)
            {
                productos = productos.Where(x => x.Nombre == request.Nombre);
            }

            if(request.IdProveedor != null)
            {
                productos = productos.Where(x => x.IdProveedor == request.IdProveedor); 
            }

            productos = productos.Where(x => x.Estado == request.Estado);

            var productosDto = _mapper.Map<IEnumerable<ProductoDto>>(productos.ToList());

            var pagedProducto = PagedList<ProductoDto>.Create(productosDto, request.PageNumber, request.PageSize);

            return Task.FromResult(pagedProducto);
        }
    }
}
