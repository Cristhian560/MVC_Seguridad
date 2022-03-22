using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Seguridad.Models
{
    public partial class Cliente
    {
        public int IdCliente { get; set; }
        [Required(ErrorMessage = "EL NOMBRE ES OBLIGATORIO")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "EL APELLIDO ES OBLIGATORIO")]
        public string? Apellido { get; set; }
        [Required(ErrorMessage = "LA DIRECCION ES OBLIGATORIA")]
        public string? Direccion { get; set; }
        public long? Telefono { get; set; }
    }
}
