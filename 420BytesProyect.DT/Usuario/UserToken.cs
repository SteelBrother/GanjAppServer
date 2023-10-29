using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420BytesProyect.DT.Usuario
{
    public class UserToken
    {
        public string? Token { get; set; }
        public string? Cedula { get; set; }
        public string? NickName { get; set; }
        public DateTime Expiration { get; set; }
        public string? ValidacionIngreso { get; set; }
    }
}
