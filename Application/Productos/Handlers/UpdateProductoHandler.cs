using Application.Common.Interfaces;
using Application.Productos.Commands.UpdateProducto;
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
    public class UpdateProductoHandler : IRequestHandler<UpdateProductoCommand>
    {
        private readonly IAutoglassContext _autoglassContext;

        public UpdateProductoHandler(IAutoglassContext autoglassContext)
        {
            _autoglassContext = autoglassContext; 
        }

        public async Task<Unit> Handle(UpdateProductoCommand request, CancellationToken cancellationToken)
        {
            var producto = _autoglassContext.Productos.Where(x => x.IdProducto == request.IdProducto).FirstOrDefault();

            if (producto == null)
                throw new NotFoundException("No se encontró el producto");

            if (request.FechaFabricacion >= request.FechaValidez)
                throw new BusinessException("la fecha de fabricacion no puede ser mayor o igual a la fecha de vencimiento");

            producto.IdProducto = request.IdProducto;
            producto.Nombre = request.Nombre;
            producto.Descripcion = request.Descripcion;
            producto.FechaFabricacion = request.FechaFabricacion;
            producto.FechaValidez = request.FechaValidez;
            producto.IdProveedor = request.IdProveedor;
            producto.Estado = request.Estado; 

            _autoglassContext.Productos.Update(producto);

            await _autoglassContext.SaveChangesAsync(cancellationToken);

            return Unit.Value; 
        }
    }
}
