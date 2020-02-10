using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Domain.Layer
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioVenta { get; set; }

        public Presentacion Presentacion { get; set; }
        public string PresentacionStr { get; set; }

    }
}
