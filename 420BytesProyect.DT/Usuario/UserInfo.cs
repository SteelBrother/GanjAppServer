using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _420BytesProyect.DT.Usuario
{
    public class UserInfo
    {
        
        [Display(Name = "CC")]
        public string? CedulaCiudadania { get; set; }
        [Display(Name = "NickName")]
        public string? NickName { get; set; }
        [Display(Name = "Contraseña")]
        public string? Password { get; set; }

    }
}
