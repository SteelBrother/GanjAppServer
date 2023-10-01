using _420BytesProyect.BM.General;
using _420BytesProyect.BM.General.Interfaces;
using _420BytesProyect.DT.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace _420BytesProyect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IBMUsuarios IBMUsuarios;
        
        public UsuariosController(IBMUsuarios IBMUsuarios)
        {
            this.IBMUsuarios = IBMUsuarios; 
        }

        [HttpGet("Usuarios")]
        public async Task<ActionResult<List<Usuario>>> ConsultarUsuario()
        {
            return await IBMUsuarios.ConsultaUsuarios();
        }
        [HttpGet("Usuario")]
        public async Task<ActionResult<Usuario>>ConsultarUsuarioXCedula(int Cedula)
        {
            return await IBMUsuarios.TraerUsuarioXCedula(Cedula);
        }


    }
}
