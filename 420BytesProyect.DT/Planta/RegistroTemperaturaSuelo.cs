using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _420BytesProyect.DT.Planta
{
    public class RegistroTemperaturaSuelo
    {
        public int Id { get; set; } 
        public int IdPlanta { get; set; }
        public decimal Temperatura {  get; set; }
        public DateTime Fecha { get; set; } 
    }
}
