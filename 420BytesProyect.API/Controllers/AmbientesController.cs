using _420BytesProyect.BM.General.Interfaces;
using _420BytesProyect.DT.Ambiente;
using _420BytesProyect.DT.Planta;
using _420BytesProyect.DT.Usuario;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _420BytesProyect.API.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

        [HttpPost("RegistrarHumedadAmbiente")]
        public async Task<ActionResult<bool>> RegistrarHumedadAmbiente(RegistroHumedadAmbiente registroHumedadAmbiente)
        {
            return await IBMAmbientes.RegistrarHumedadAmbiente(registroHumedadAmbiente);
        }

        [HttpPost("RegistrarIntensidadLuz")]
        public async Task<ActionResult<bool>> RegistrarIntensidadLuz(RegistroIntensidadLuz registroIntensidadLuz)
        {
            return await IBMAmbientes.RegistrarIntensidadLuz(registroIntensidadLuz);
        }

        [HttpGet("ConsultarLastTemp")]
        public async Task<RegistroTemperaturaAmbiente> ConsultarLastTemp(int IdAmbiente)
        {
            return await IBMAmbientes.ConsultarLastTemp(IdAmbiente);
        }
        [HttpGet("ConsultarAmbientes")]
        public async Task<List<Ambiente>> ConsultarAmbientesPlantas(int Cedula)
        {
            return await IBMAmbientes.ConsultarAmbientes(Cedula);
        }
        [HttpGet("ConsultarPlantasAmbientes")]
        public async Task<List<Planta2>> ConsultarPlantas(int AmbienteId)
        {
            return await IBMAmbientes.ConsultarPlantas(AmbienteId);
        }
        [HttpGet("ConsultarLastHum")]
        public async Task<RegistroHumedadAmbiente> ConsultarLastHum(int IdAmbiente)
        {
            return await IBMAmbientes.ConsultarLastHum(IdAmbiente);
        }
        [HttpGet("ConsultarLastLight")]
        public async Task<RegistroIntensidadLuz> ConsultarLastLight(int IdAmbiente)
        {
            return await IBMAmbientes.ConsultarLastLight(IdAmbiente);
        }
        [HttpPost("RegistrarAmbiente")]
        public async Task<ActionResult<Ambiente>> RegistrarAmbiente(Ambiente ambiente)
        {
            return await IBMAmbientes.RegistrarAmbiente(ambiente);
        }
    }
}
