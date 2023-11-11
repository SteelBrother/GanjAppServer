using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420BytesProyect.DT.Ambiente
{
    public class RegistroCO2
    {
        public int Id { get; set; }
        public int IdAmbiente { get; set; }
        public decimal CO2 { get; set; }
        public DateTime Fecha { get; set; }
    }
}
