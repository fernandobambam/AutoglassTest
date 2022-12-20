using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaFabricacion { get; set; }
        public DateTime? FechaValidez { get; set; }
        public int? IdProveedor { get; set; }
        public bool? Estado { get; set; }

        public virtual Proveedor IdProveedorNavigation { get; set; }
    }
}
