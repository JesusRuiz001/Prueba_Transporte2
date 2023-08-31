using System;
using System.Collections.Generic;

namespace Prueba_Transporte2.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Envios = new HashSet<Envio>();
        }

        public int ProductoId { get; set; }
        public string? Nombre { get; set; }
        public int? Stock { get; set; }
        public double? ValorUnit { get; set; }

        public virtual ICollection<Envio> Envios { get; set; }
    }
}
