using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420BytesProyect.DT.Identity
{
    public class CambioContrasena
    {
        public int Id { get; set; }
        public int TipoIngresoId { get; set; }
        public string? Usuario { get; set; }
        [Display(Name = "Nueva contraseña")]
        public string? Clave { get; set; }
        [Display(Name = "Repetir contraseña")]
        public string? RepetirClave { get; set; }
    }
}
