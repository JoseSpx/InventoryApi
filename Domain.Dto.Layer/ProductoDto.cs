using Domain.Layer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dto.Layer
{
    public class ProductoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioVenta { get; set; }
        public Presentacion Presentacion { get; set; }
    }
}
