﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Productos.Commands.UpdateProducto
{
    public class UpdateProductoValidator : AbstractValidator<UpdateProductoCommand>
    {
        public UpdateProductoValidator()
        {
            RuleFor(producto => producto.IdProducto)
                .NotNull();

            RuleFor(producto => producto.Nombre)
                .NotNull()
                .MaximumLength(50);

            RuleFor(producto => producto.Descripcion)
                .NotNull()
                .MaximumLength(100);
        }
    }
}
