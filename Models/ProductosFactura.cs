using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaTecnicaSxo.Models
{
    public partial class ProductosFactura
    {
        public int? IdFactura { get; set; }
        public int? IdProducto { get; set; }

        public virtual Factura IdFacturaNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
    }
}
