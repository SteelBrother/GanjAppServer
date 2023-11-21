using _420BytesProyect.BM.General.Interfaces;
using _420BytesProyect.BM.HubMsj;
using _420BytesProyect.DM;
using _420BytesProyect.DT.Ambiente;
using _420BytesProyect.DT.Identity;
using _420BytesProyect.DT.Planta;
using _420BytesProyect.DT.Usuario;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _420BytesProyect.BM.General
{
    public class BMAmbientes : IBMAmbientes
    {
        private readonly IConexionBD conexionBD;
        private readonly ILogger<IBMAmbientes> logger;
        private readonly IHubContext<AmbienteUpdatesHub> AmbienteUpdatesHub;
        public BMAmbientes(IConexionBD conexionBD, ILogger<IBMAmbientes> logger, IHubContext<AmbienteUpdatesHub> AmbienteUpdatesHub)
        {
            this.conexionBD = conexionBD;
            this.logger = logger;
            this.AmbienteUpdatesHub = AmbienteUpdatesHub;

        }
        public async Task<Ambiente> RegistrarAmbiente(Ambiente Ambiente)
        {
            try
            {
                var ambiente = await conexionBD.QueryFirstAsync<Ambiente>("Ambiente.SP_RegistrarAmbiente", new { Ambiente });
                return Ambiente;
            }
            catch (Exception ex)
            {
                logger.LogError($"Clase: {GetType().Name}, Metodo: {MethodBase.GetCurrentMethod()?.DeclaringType?.Name}, Tipo: {ex.GetType()}, Error: {ex.Message}");
                return new Ambiente();
            }
        }
        public async Task<List<Ambiente>> ConsultarAmbientes()
        {
            try
            {
                var Ambientes = await conexionBD.QueryAsync<Ambiente>("Ambiente.SP_ConsultarAmbientes");
                if (Ambientes != null)
                {
                    //await UsuarioHub.Clients.All.SendAsync("UsuariosActualizados", usuarios);
                    return Ambientes.ToList();
                }
                return new List<Ambiente>();
            }
            catch (Exception ex)
            {
                logger.LogError($"Clase: {GetType().Name}, Metodo: {MethodBase.GetCurrentMethod()?.DeclaringType?.Name}, Tipo: {ex.GetType()}, Error: {ex.Message}");
                return new List<Ambiente>();
            }
        }

        public async Task<RegistroHumedadAmbiente> ConsultarLastHum(int IdAmbiente)
        {
            try
            {
                var RegistroHumedadAmbiente = await conexionBD.QueryFirstAsync<RegistroHumedadAmbiente>("Ambiente.SP_ConsultarLastHum", new { IdAmbiente });
                return RegistroHumedadAmbiente;
            }
            catch (Exception ex)
            {
                logger.LogError($"Clase: {GetType().Name}, Metodo: {MethodBase.GetCurrentMethod()?.DeclaringType?.Name}, Tipo: {ex.GetType()}, Error: {ex.Message}");
                return new RegistroHumedadAmbiente();
            }
        }

        public async Task<RegistroIntensidadLuz> ConsultarLastLight(int IdAmbiente)
        {
            try
            {
                var RegistroIntensidadLuz = await conexionBD.QueryFirstAsync<RegistroIntensidadLuz>("Ambiente.SP_ConsultarLastLight", new { IdAmbiente });
                return RegistroIntensidadLuz;
            }
            catch (Exception ex)
            {
                logger.LogError($"Clase: {GetType().Name}, Metodo: {MethodBase.GetCurrentMethod()?.DeclaringType?.Name}, Tipo: {ex.GetType()}, Error: {ex.Message}");
                return new RegistroIntensidadLuz();
            }
        }

        public async Task<RegistroTemperaturaAmbiente> ConsultarLastTemp(int IdAmbiente)
        {
            try
            {
                var RegistroTemperaturaAmbiente = await conexionBD.QueryFirstAsync<RegistroTemperaturaAmbiente>("Ambiente.SP_ConsultarLastTemp", new { IdAmbiente });
                return RegistroTemperaturaAmbiente;
            }
            catch (Exception ex)
            {
                logger.LogError($"Clase: {GetType().Name}, Metodo: {MethodBase.GetCurrentMethod()?.DeclaringType?.Name}, Tipo: {ex.GetType()}, Error: {ex.Message}");
                return new RegistroTemperaturaAmbiente();
            }
        }

        public async Task<bool> RegistrarIntensidadLuz(RegistroIntensidadLuz RegistroIntensidadLuz)
        {
            try
            {
                var Respuesta = await conexionBD.QueryFirstAsync<bool>("Dispositivo.SP_RegistrarIntensidadLuz", new { RegistroIntensidadLuz = JsonSerializer.Serialize(RegistroIntensidadLuz) });
                if (Respuesta)
                {
                    await AmbienteUpdatesHub.Clients.All.SendAsync("LuzAmbiente", RegistroIntensidadLuz);
                    return Respuesta;
                }
                return false;
            }
            catch (Exception ex)
            {

                logger.LogError($"Clase: {GetType().Name}, Metodo: {MethodBase.GetCurrentMethod()?.DeclaringType?.Name}, Tipo: {ex.GetType()}, Error: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> RegistrarHumedadAmbiente(RegistroHumedadAmbiente RegistroHumedadAmbiente)
        {
            try
            {
                var Respuesta = await conexionBD.QueryFirstAsync<bool>("Dispositivo.SP_RegistrarHumedadAmbiente", new { RegistroHumedadAmbiente = JsonSerializer.Serialize(RegistroHumedadAmbiente) });
                if (Respuesta)
                {
                    await AmbienteUpdatesHub.Clients.All.SendAsync("HumedadAmbiente", RegistroHumedadAmbiente);
                    return Respuesta;
                }
                return false;
            }
            catch (Exception ex)
            {

                logger.LogError($"Clase: {GetType().Name}, Metodo: {MethodBase.GetCurrentMethod()?.DeclaringType?.Name}, Tipo: {ex.GetType()}, Error: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> RegistrarTemperaturaAmbiente(RegistroTemperaturaAmbiente RegistroTemperaturaAmbiente)
        {
            try
            {
                var Respuesta = await conexionBD.QueryFirstAsync<bool>("Dispositivo.SP_RegistrarTemperaturaAmbiente", new { RegistroTemperaturaAmbiente = JsonSerializer.Serialize(RegistroTemperaturaAmbiente) });
                if (Respuesta)
                {
                    await AmbienteUpdatesHub.Clients.All.SendAsync("TemperaturaAmbiente", RegistroTemperaturaAmbiente);
                    return Respuesta;
                }
                return false;
            }
            catch (Exception ex)
            {

                logger.LogError($"Clase: {GetType().Name}, Metodo: {MethodBase.GetCurrentMethod()?.DeclaringType?.Name}, Tipo: {ex.GetType()}, Error: {ex.Message}");
                return false;
            }
        }

        public async Task<List<Ambiente>> ConsultarAmbientes(int Cedula)
        {
            try
            {
                List<Planta2> ListaPlantas = new List<Planta2>();
                var ambientes = await conexionBD.QueryAsync<Ambiente>("Ambiente.ConsultarAmbientes", new { Cedula});
                if (ambientes != null)
                {
                    return ambientes.ToList();
                }
                return new List<Ambiente>();
            }
            catch (Exception ex)
            {
                logger.LogError($"Clase: {GetType().Name}, Metodo: {MethodBase.GetCurrentMethod()?.DeclaringType?.Name}, Tipo: {ex.GetType()}, Error: {ex.Message}");
                return new List<Ambiente> { };
            }
        }

        public async Task<List<Planta2>> ConsultarPlantas(int AmbienteId)
        {
            try
            {
                List<Planta2> ListaPlantas = new List<Planta2>();
                var plantas = await conexionBD.QueryAsync<Planta2>("Ambiente.ConsultarPlantas", new { AmbienteId });
                if (plantas != null)
                {
                    return plantas.ToList();
                }
                return new List<Planta2>();
            }
            catch (Exception ex)
            {
                logger.LogError($"Clase: {GetType().Name}, Metodo: {MethodBase.GetCurrentMethod()?.DeclaringType?.Name}, Tipo: {ex.GetType()}, Error: {ex.Message}");
                return new List<Planta2> { };
            }
        }
    }
}
