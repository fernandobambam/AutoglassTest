﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Productos.Commands.UpdateProducto
{
    public class UpdateProductoCommand : IRequest
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaFabricacion { get; set; }
        public DateTime? FechaValidez { get; set; }
        public int? IdProveedor { get; set; }
        public bool Estado { get; set; }
    }
}
