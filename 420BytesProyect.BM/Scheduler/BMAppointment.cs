using _420BytesProyect.BM.General.Interfaces;
using _420BytesProyect.BM.Scheduler.Interfaces;
using _420BytesProyect.DM;
using _420BytesProyect.DT.Dispositivo;
using _420BytesProyect.DT.Scheduler;
using _420BytesProyect.DT.Usuario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _420BytesProyect.BM.Scheduler
{
    public class BMAppointment : IBMAppointment
    {
        private readonly IConexionBD conexionBD;
        private readonly ILogger<IBMAppointment> logger;
        public BMAppointment(IConexionBD conexionBD, ILogger<IBMAppointment> logger)
        {
            this.conexionBD = conexionBD;
            this.logger = logger;

        }

        public async Task<List<AppointmentData>> ActualizarCita(AppointmentDataDTO appointmentDataDTO)
        {
            try
            {
                var citas = await conexionBD.QueryAsync<AppointmentData>("Usuario.TraerUsuarios");
                if (citas != null)
                {
                    return citas.ToList();
                }
                return new List<AppointmentData>();
            }
            catch (Exception ex)
            {
                logger.LogError($"Clase: {GetType().Name}, Metodo: {MethodBase.GetCurrentMethod()?.DeclaringType?.Name}, Tipo: {ex.GetType()}, Error: {ex.Message}");
                return new List<AppointmentData>();
            }
        }

        public async Task<List<AppointmentData>> BorrarCita(AppointmentDataDTO appointmentDataDTO)
        {
            try
            {
                var usuarios = await conexionBD.QueryAsync<AppointmentData>("Usuario.TraerUsuarios");
                if (usuarios != null)
                {
                    return usuarios.ToList();
                }
                return new List<AppointmentData>();
            }
            catch (Exception ex)
            {
                logger.LogError($"Clase: {GetType().Name}, Metodo: {MethodBase.GetCurrentMethod()?.DeclaringType?.Name}, Tipo: {ex.GetType()}, Error: {ex.Message}");
                return new List<AppointmentData>();
            }
        }

        public async Task<List<AppointmentData>> ConsultarCitasPorCedula(int Cedula)
        {
            try
            {
                var usuarios = await conexionBD.QueryAsync<AppointmentData>("Scheduler.SP_ConsultarCitasPorCedula", new { Cedula });
                if (usuarios != null)
                {
                    
                    return usuarios.ToList();
                }
                return new List<AppointmentData>();
            }
            catch (Exception ex)
            {
                logger.LogError($"Clase: {GetType().Name}, Metodo: {MethodBase.GetCurrentMethod()?.DeclaringType?.Name}, Tipo: {ex.GetType()}, Error: {ex.Message}");
                return new List<AppointmentData>();
            }
        }

        public async Task<List<AppointmentData>> RegistrarCita(AppointmentDataDTO appointmentDataDTO)
        {
            try
            {
                var Respuesta = await conexionBD.QueryFirstAsync<bool>("Scheduler.SP_RegistrarCita", new { AppointmentDataDTO = JsonSerializer.Serialize(appointmentDataDTO) }); ;
                return new List<AppointmentData>();
            }
            catch (Exception ex)
            {
                logger.LogError($"Clase: {GetType().Name}, Metodo: {MethodBase.GetCurrentMethod()?.DeclaringType?.Name}, Tipo: {ex.GetType()}, Error: {ex.Message}");
                return new List<AppointmentData>();
            }
        }
    }
}
