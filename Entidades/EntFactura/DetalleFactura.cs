//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entidades.EntFactura
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetalleFactura
    {
        public long Id { get; set; }
        public long IdFactura { get; set; }
        public string Producto { get; set; }
        public Nullable<int> Cantidad { get; set; }
        public Nullable<decimal> Importe { get; set; }
        public Nullable<decimal> SubTotal { get; set; }
        public Nullable<decimal> Iva { get; set; }
        public Nullable<decimal> Total { get; set; }
    
        public virtual Factura Factura { get; set; }
    }
}
