using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420BytesProyect.DT.Ambiente
{
    public class ControlHumedadAmbiente
    {
        public int Id { get; set; }
        public int? IdTipoSuelo { get; set; }
        public int? IdTipoCultivo { get; set; }
        public string HumedadMin { get; set; }
        public string HumedadMax { get; set; }
    }

}
