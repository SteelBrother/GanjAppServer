using _420BytesProyect.BM.General.Interfaces;
using _420BytesProyect.DM;
using _420BytesProyect.DT.Planta;
using Microsoft.Extensions.Logging;
using _420BytesProyect.DT.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Text.Json;
using _420BytesProyect.BM.HubMsj;
using _420BytesProyect.DT.Ambiente;
using Microsoft.AspNetCore.SignalR;

namespace _420BytesProyect.BM.General
{
    public class BMPlanta : IBMPlantas
    {
        private readonly IConexionBD conexionBD;
        private readonly ILogger<IBMPlantas> logger;
        private readonly IHubContext<AmbienteUpdatesHub> AmbienteUpdatesHub;

        public BMPlanta(IConexionBD conexionBD, ILogger<IBMPlantas> logger, IHubContext<AmbienteUpdatesHub> AmbienteUpdatesHub)
        {
            this.conexionBD = conexionBD;
            this.logger = logger;
            this.AmbienteUpdatesHub = AmbienteUpdatesHub;

        }
        public async Task<bool> RegistrarHumedadSuelo(RegistroHumedadSuelo RegistroHumedadSuelo)
        {
            try
            {
                var Respuesta = await conexionBD.QueryFirstAsync<bool>("Planta.SP_RegistrarHumedadSuelo", new { RegistroHumedadSuelo = JsonSerializer.Serialize(RegistroHumedadSuelo) });
                return Respuesta;
            }
            catch (Exception ex)
            {

                logger.LogError($"Clase: {GetType().Name}, Metodo: {MethodBase.GetCurrentMethod()?.DeclaringType?.Name}, Tipo: {ex.GetType()}, Error: {ex.Message}");
                return false;
            }
        }


        public async Task<List<Planta>> ConsultarListaDePlantas()
        {
            try
            {
                var plantas = await conexionBD.QueryAsync<Planta>("Planta.SP_ConsultarListaDePlantas");
                return plantas.ToList();
            }
            catch (Exception ex)
            {
                logger.LogError($"Clase: {GetType().Name}, Metodo: {MethodBase.GetCurrentMethod()?.DeclaringType?.Name}, Tipo: {ex.GetType()}, Error: {ex.Message}");
                return new List<Planta>();
            }
        }
        public async Task<Planta> RegistrarPlanta(Planta Planta)
        {
            try
            {
                var planta = await conexionBD.QueryFirstAsync<Planta>("Planta.SP_RegistrarPlanta", new { Planta });
                return planta;
            }
            catch (Exception ex)
            {
                logger.LogError($"Clase: {GetType().Name}, Metodo: {MethodBase.GetCurrentMethod()?.DeclaringType?.Name}, Tipo: {ex.GetType()}, Error: {ex.Message}");
                return new Planta();
            }
        }

        public async Task<bool> RegistrarNivelAgua(RegistroNivelAgua RegistroNivelAgua)
        {
            try
            {
                var Respuesta = await conexionBD.QueryFirstAsync<bool>("Planta.SP_RegistrarNivelAgua", new { RegistroNivelAgua = JsonSerializer.Serialize(RegistroNivelAgua) });
                if (Respuesta)
                {
                    await AmbienteUpdatesHub.Clients.All.SendAsync("NivelAguaPlanta", RegistroNivelAgua);
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
        public async Task<List<PlantaxUsuario>>ConsultarPlantasPorUsuario(int Cedula)
        {
            try
            {
                var plantas = await conexionBD.QueryAsync<PlantaxUsuario>("Planta.SP_ConsultarPlantasPorUsuario", new { Cedula });
                return plantas.ToList();
            }
            catch (Exception ex)
            {
                logger.LogError($"Clase: {GetType().Name}, Metodo: {MethodBase.GetCurrentMethod()?.DeclaringType?.Name}, Tipo: {ex.GetType()}, Error: {ex.Message}");
                return new List<PlantaxUsuario>();
            }
        }
    }
}
