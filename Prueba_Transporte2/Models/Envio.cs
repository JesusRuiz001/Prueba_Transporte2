using System;
using System.Collections.Generic;

namespace Prueba_Transporte2.Models
{
    public partial class Envio
    {
        public int EnvioId { get; set; }
        public int? ClienteId { get; set; }
        public int? ProductoId { get; set; }
        public int? Cantidad { get; set; }
        public string? Placa { get; set; }
        public decimal? PrecioEnvio { get; set; }
        public decimal? PrecioEnvioNeto { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public string? NumeroGuia { get; set; }
        public int? BodegaId { get; set; }

        public virtual Bodega? Bodega { get; set; }
        public virtual Cliente? Cliente { get; set; }
        public virtual Vehiculo? PlacaNavigation { get; set; }
        public virtual Producto? Producto { get; set; }
    }
}
