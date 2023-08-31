using System;
using System.Collections.Generic;

namespace Prueba_Transporte2.Models
{
    public partial class Bodega
    {
        public Bodega()
        {
            Envios = new HashSet<Envio>();
        }

        public int BodegaId { get; set; }
        public string? Nombre { get; set; }
        public string? Ubicacion { get; set; }

        public virtual ICollection<Envio> Envios { get; set; }
    }
}
