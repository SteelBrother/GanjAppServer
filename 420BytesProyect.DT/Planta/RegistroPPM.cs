using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420BytesProyect.DT.Planta
{
    public class RegistroPPM
    {
        public int Id { get; set; }
        public int IdPlanta {  get; set; }
        public decimal PPM { get; set; }
        public DateTime Fecha { get; set; }
    }
}
