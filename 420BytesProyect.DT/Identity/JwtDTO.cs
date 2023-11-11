using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _420BytesProyect.DT.Identity
{
    public class JwtDTO
    {
        public int Id { get; set; }
        public string? NombreUsuario { get; set; }
        public string? Cedula { get; set; }
        public string? ValidacionIngreso { get; set; }
        public List<Rol>? RolesSeleccionados { get; set; }
    }
}
