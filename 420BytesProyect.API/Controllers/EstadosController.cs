using _420BytesProyect.BM.General;
using _420BytesProyect.BM.General.Interfaces;
using _420BytesProyect.DT.Estado;
using _420BytesProyect.DT.Usuario;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _420BytesProyect.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : ControllerBase
    {
        private IBMEstados IBMEstados;

        public EstadosController(IBMEstados IBMEstados) { 

            this.IBMEstados = IBMEstados;   
        }

        [HttpPut("ActualizarEstadoDeLaPlanta")]
        public async Task<ActionResult<string>> ActualizarEstadoDeLaPlanta(Estado Estado)
        {
            return await IBMEstados.ActualizarEstadoDeLaPlanta(Estado);
        }
    }
}
