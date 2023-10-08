using _420BytesProyect.BM.General.Interfaces;
using _420BytesProyect.DT.Planta;
using Microsoft.AspNetCore.Mvc;

namespace _420BytesProyect.API.Controllers
{
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

    }
}
