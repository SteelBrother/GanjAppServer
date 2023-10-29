using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420BytesProyect.DT.Identity
{
    public class Rol
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public bool Estado { get; set; }

        public string oEstado
        {
            get
            {
                if (Estado != false)
                {
                    return ("Activo");
                }
                else
                {
                    return ("Inactivo");
                }
            }
        }
    }
}
