using System;
using System.Collections.Generic;

namespace Prueba_Transporte2.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Envios = new HashSet<Envio>();
        }

        public int ClienteId { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }

        public virtual ICollection<Envio> Envios { get; set; }
    }
}
