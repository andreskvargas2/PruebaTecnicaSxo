using System;
using System.Collections.Generic;


namespace PruebaTecnicaSxo.Models
{
    public partial class Factura
    {
        public int IdFactura { get; set; }
        public string NumeroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoDePago { get; set; }
        public string DocumentoCliente { get; set; }
        public string NombreCliente { get; set; }
        public double Subtotal { get; set; }
        public double? Descuento { get; set; }
        public double? Iva { get; set; }
        public double? TotalDescuento { get; set; }
        public double? TotalImpuesto { get; set; }
        public double Total { get; set; }
    }
}
