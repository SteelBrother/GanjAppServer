using _420BytesProyect.DT.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420BytesProyect.BM.General.Interfaces
{
    public interface IBMUsuarios
    {
        Task<List<Usuario>> ConsultaUsuarios();
        Task<Usuario> TraerUsuarioXCedula(int Cedula);
    }
 
}
