using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420BytesProyect.DT.Feed
{
    public class Comentario
    {
        public int ComentarioID { get; set; }
        public int? UsuarioID { get; set; }
        public int? PublicacionID { get; set; }
        public string Contenido { get; set; }
        public DateTime? FechaComentario { get; set; }
    }
}
