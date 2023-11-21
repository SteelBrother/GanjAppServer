using _420BytesProyect.BM.General.Interfaces;
using _420BytesProyect.BM.Identity.Interfaces;
using _420BytesProyect.BM.Scheduler.Interfaces;
using _420BytesProyect.DT.Scheduler;
using _420BytesProyect.DT.Usuario;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _420BytesProyect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : Controller
    {

        private IBMAppointment IBMAppointment;

        public AppointmentController(IBMAppointment IBMAppointment)
        {
            this.IBMAppointment = IBMAppointment;
        }

        [HttpGet("ConsultarCita")]
        public async Task<ActionResult<List<AppointmentData>>> ConsultarCitasPorCedula(int UsuarioId, int IdAmbiente, int IdPlanta)
        {
            return await IBMAppointment.ConsultarCitasPorCedula(UsuarioId,IdAmbiente,IdPlanta);
        }

        [HttpPost("RegistrarCita")]
        public async Task<ActionResult<List<AppointmentData>>> RegistrarCita([FromBody] AppointmentDataDTO AppointmentDataDTO)
        {
            return await IBMAppointment.RegistrarCita(AppointmentDataDTO);
        }

        [HttpPut("ActualizarCita")]
        public async Task<ActionResult<List<AppointmentData>>> ActualizarCita(AppointmentDataDTO AppointmentDataDTO)
        {
            return await IBMAppointment.ActualizarCita(AppointmentDataDTO);

        }

        [HttpDelete("BorrarCita")]
        public async Task<ActionResult<List<AppointmentData>>> BorrarUsuario(AppointmentDataDTO AppointmentDataDTO)
        {
            return await IBMAppointment.BorrarCita(AppointmentDataDTO);

        }

    }
}
