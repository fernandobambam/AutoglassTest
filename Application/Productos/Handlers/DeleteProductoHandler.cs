using Application.Common.Interfaces;
using Application.Productos.Commands.DeleteProducto;
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
    public class DeleteProductoHandler : IRequestHandler<DeleteProductoCommand>
    {
        private readonly IAutoglassContext _autoglassContext;

        public DeleteProductoHandler(IAutoglassContext autoglassContext) 
        {
            _autoglassContext = autoglassContext; 
        }

        public async Task<Unit> Handle(DeleteProductoCommand request, CancellationToken cancellationToken)
        {
            var producto = await _autoglassContext.Productos.FindAsync(request.Id);

            if (producto == null)
                throw new NotFoundException("No se encontró el producto");


            producto.Estado = false;

            _autoglassContext.Productos.Update(producto);

            await _autoglassContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
