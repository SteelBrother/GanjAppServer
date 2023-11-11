using _420BytesProyect.BM.General.Interfaces;
using _420BytesProyect.DT.Ambiente;
using _420BytesProyect.DT.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _420BytesProyect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmbientesController : ControllerBase
    {
        private IBMAmbientes IBMAmbientes;
        public AmbientesController(IBMAmbientes IBMAmbientes)
        {
            this.IBMAmbientes = IBMAmbientes;
        }
        [HttpPost("RegistrarTemperaturaAmbiente")]
        public async Task<ActionResult<bool>> RegistrarTemperaturaAmbiente(RegistroTemperaturaAmbiente registroTemperaturaAmbiente)
        {
            return await IBMAmbientes.RegistrarTemperaturaAmbiente(registroTemperaturaAmbiente);
        }
    }
}
