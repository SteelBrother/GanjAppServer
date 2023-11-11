using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420BytesProyect.DT.Feed
{
    public class Publicacion
    {
        public int PublicacionID { get; set; }
        public int UsuarioID { get; set; }
        public string? Contenido { get; set; }
        public DateTime FechaPublicacion {  get; set; }
    }
}
