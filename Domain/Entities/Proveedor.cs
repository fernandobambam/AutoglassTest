using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Productos = new HashSet<Producto>();
        }

        public int IdProveedor { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
