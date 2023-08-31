using System;
using System.Collections.Generic;

namespace Prueba_Transporte2.Models
{
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            Envios = new HashSet<Envio>();
        }

        public string Placa { get; set; } = null!;
        public string? TipoVehiculo { get; set; }

        public virtual ICollection<Envio> Envios { get; set; }
    }
}
