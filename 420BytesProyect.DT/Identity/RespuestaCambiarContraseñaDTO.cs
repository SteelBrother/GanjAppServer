using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420BytesProyect.DT.Identity
{
    public class RespuestaCambiarContraseñaDTO
    {
        public string? Id { get; set; }
        public string? Destinatario { get; set; }
        public string? Validacion { get; set; }
    }
}
