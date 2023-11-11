using _420BytesProyect.BM.General.Interfaces;
using _420BytesProyect.DM;
using _420BytesProyect.DT.Ambiente;
using _420BytesProyect.DT.Usuario;
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
        public BMAmbientes(IConexionBD conexionBD, ILogger<IBMAmbientes> logger)
        {
            this.conexionBD = conexionBD;
            this.logger = logger;

        }

        public async Task<bool> RegistrarTemperaturaAmbiente(RegistroTemperaturaAmbiente RegistroTemperaturaAmbiente)
        {
            try
            {
                var Respuesta = await conexionBD.QueryFirstAsync<bool>("Dispositivo.SP_RegistrarTemperaturaAmbiente", new { RegistroTemperaturaAmbiente = JsonSerializer.Serialize(RegistroTemperaturaAmbiente) });
                return Respuesta;
            }
            catch (Exception ex)
            {

                logger.LogError($"Clase: {GetType().Name}, Metodo: {MethodBase.GetCurrentMethod()?.DeclaringType?.Name}, Tipo: {ex.GetType()}, Error: {ex.Message}");
                return false;
            }
        }
    }
}
