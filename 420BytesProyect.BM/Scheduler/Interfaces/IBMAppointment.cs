using _420BytesProyect.DT.Scheduler;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420BytesProyect.BM.Scheduler.Interfaces
{
    public interface IBMAppointment
    {
        Task<List<AppointmentData>> ActualizarCita(AppointmentDataDTO appointmentDataDTO);
        Task<List<AppointmentData>> BorrarCita(AppointmentDataDTO appointmentDataDTO);
        Task<List<AppointmentData>> ConsultarCitasPorCedula(int Cedula);
        Task<List<AppointmentData>> RegistrarCita(AppointmentDataDTO appointmentDataDTO);
    }
}
