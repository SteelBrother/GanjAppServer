using _420BytesProyect.BM.General.Interfaces;
using _420BytesProyect.DT.Planta;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _420BytesProyect.API.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class PlantasController : ControllerBase
    {
        private IBMPlantas IBMPlanta;

        public PlantasController(IBMPlantas IBMPlanta)
        {
            this.IBMPlanta = IBMPlanta;
        }

        [HttpGet("ConsultarListaDePlantas")]
        public async Task<ActionResult<List<Planta>>> ConsultarListaDePlantas()
        {
            return await IBMPlanta.ConsultarListaDePlantas();
        }

        [HttpGet("PlantasPorUsuario")]
        public async Task<ActionResult<List<PlantaxUsuario>>> ConsultarPlantasPorUsuario(int Cedula)
        {
            return await IBMPlanta.ConsultarPlantasPorUsuario(Cedula);
        }

        [HttpPost("RegistrarHumedadSuelo")]
        public async Task<ActionResult<bool>> RegistrarHumedadSuelo(RegistroHumedadSuelo registroHumedadSuelo)
        {
            return await IBMPlanta.RegistrarHumedadSuelo(registroHumedadSuelo);
        }
        [HttpPost("RegistrarNivelAgua")]
        public async Task<ActionResult<bool>> RegistrarNivelAgua(RegistroNivelAgua RegistroNivelAgua)
        {
            return await IBMPlanta.RegistrarNivelAgua(RegistroNivelAgua);
        }
        [HttpPost("RegistrarPlanta")]
        public async Task<ActionResult<Planta>> RegistrarPlanta(Planta planta)
        {
            return await IBMPlanta.RegistrarPlanta(planta);
        }
    }
}
