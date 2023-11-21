using _420BytesProyect.DT.Ambiente;
using _420BytesProyect.DT.Planta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420BytesProyect.BM.General.Interfaces
{
    public interface IBMAmbientes
    {
        Task<bool> RegistrarTemperaturaAmbiente(RegistroTemperaturaAmbiente RegistroTemperaturaAmbiente);
        Task<bool> RegistrarHumedadAmbiente(RegistroHumedadAmbiente RegistroHumedadAmbiente);
        Task<bool> RegistrarIntensidadLuz(RegistroIntensidadLuz RegistroIntensidadLuz);
        Task<RegistroTemperaturaAmbiente> ConsultarLastTemp(int IdAmbiente);
        Task<List<Ambiente>> ConsultarAmbientes(int Cedula);
        Task<Ambiente> RegistrarAmbiente(Ambiente Ambiente);
        Task<List<Planta2>> ConsultarPlantas(int AmbienteId);
        Task<RegistroHumedadAmbiente> ConsultarLastHum(int IdAmbiente);
        Task<RegistroIntensidadLuz> ConsultarLastLight(int IdAmbiente);
    }
}
