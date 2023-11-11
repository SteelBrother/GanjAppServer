using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420BytesProyect.DT.Ambiente
{
    public class Ambiente
    {
        public int AmbienteID {  get; set; }
        public int UsuarioID { get; set; }
        public string? NombreAmbiente { get; set; }
        public int IdTipoSuelo { get; set; }
        public int IdTipoCultivo { get; set; }
    }
}
