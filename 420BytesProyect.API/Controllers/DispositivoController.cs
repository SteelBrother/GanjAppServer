using _420BytesProyect.BM.General.Interfaces;
using _420BytesProyect.DT.Dispositivo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace _420BytesProyect.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class DispositivoController : ControllerBase
    {
        private IBMDispositivos IBMDispositivo;
       
        public DispositivoController(IBMDispositivos IBMDispositivo)
        {
                this.IBMDispositivo = IBMDispositivo;   
        }

        [HttpGet("ConsultarDispositivos")]

        public async Task<ActionResult<List<Dispositivo>>> ConsultarDispositivos()
        {
            return await IBMDispositivo.ConsultarDispositivos();
        }
    }
}

