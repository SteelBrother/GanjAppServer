using _420BytesProyect.BM.Identity;
using _420BytesProyect.BM.Identity.Interfaces;
using _420BytesProyect.DT.Usuario;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _420BytesProyect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {

        private IBMIdentity IBMIdentity;

        public AuthController(IBMIdentity IBMIdentity)
        {
            this.IBMIdentity = IBMIdentity;
        }

        [HttpGet("RenovarToken/{TipoIngresoId}/{CompaniaId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<UserToken>> RenovarToken(int TipoIngresoId, int CompaniaId)
        {
            return await IBMIdentity.RenovarToken(int.Parse(HttpContext.User.Identity.Name), TipoIngresoId, CompaniaId);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserToken?>?> Login([FromBody] UserInfo userInfo)
        {
            return await IBMIdentity.Login(userInfo);
        }

    }
}
