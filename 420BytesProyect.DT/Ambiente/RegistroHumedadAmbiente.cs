using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420BytesProyect.DT.Ambiente
{
    public class RegistroHumedadAmbiente
    {
        public int Id { get; set; }
        public int IdAmbiente { get; set; }
        public decimal Humedad { get; set; }
        public DateTime Fecha { get; set; }
    }
}
