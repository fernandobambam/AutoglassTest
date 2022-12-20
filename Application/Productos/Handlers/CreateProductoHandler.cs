using Application.Common.Interfaces;
using Application.Productos.Commands.CreateProducto;
using Domain.Entities;
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
    public class CreateProductoHandler : IRequestHandler<CreateProductoCommand>
    {
        private readonly IAutoglassContext _autoglassContext;

        public CreateProductoHandler(IAutoglassContext autoglassContext)
        {
            _autoglassContext = autoglassContext; 
        }

        public async Task<Unit> Handle(CreateProductoCommand request, CancellationToken cancellationToken)
        {
            if (request.FechaFabricacion >= request.FechaValidez)
                throw new BusinessException("la fecha de fabricacion no puede ser mayor o igual a la fecha de vencimiento");

            var producto = new Producto
            {
                Nombre = request.Nombre,
                Descripcion = request.Descripcion,
                FechaValidez = request.FechaValidez,
                FechaFabricacion = request.FechaFabricacion,
                IdProveedor = request.IdProveedor,
                Estado = true 
            };

            await _autoglassContext.Productos.AddAsync(producto);

            await _autoglassContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
