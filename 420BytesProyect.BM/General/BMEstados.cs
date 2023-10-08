using _420BytesProyect.BM.General.Interfaces;
using _420BytesProyect.DM;
using _420BytesProyect.DT.Estado;
using Microsoft.Extensions.Logging;
using System.Reflection;
using _420BytesProyect.DT.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _420BytesProyect.BM.General
{
    public class BMEstados : IBMEstados
    {
        private readonly IConexionBD conexionBD;
        private readonly ILogger<IBMEstados> logger;

        public BMEstados(IConexionBD conexionBD, ILogger<IBMEstados> logger)
        {
            this.conexionBD = conexionBD;
            this.logger = logger;
        }

        public async Task<string> ActualizarEstadoDeLaPlanta(Estado Estado)
        {
            try
            {
                var respuesta = await conexionBD.QueryFirstAsync<string>("Planta.SP_ActualizarEstadoPlanta", new { Estado = JsonSerializer.Serialize(Estado) });
                return respuesta;
            }
            catch (Exception ex)
            {
                logger.LogError($"Clase: {GetType().Name}, Metodo: {MethodBase.GetCurrentMethod()?.DeclaringType?.Name}, Tipo: {ex.GetType()}, Error: {ex.Message}");
                return "Error";
            }
        }
    }
}
