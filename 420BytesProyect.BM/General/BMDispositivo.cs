using _420BytesProyect.BM.General.Interfaces;
using _420BytesProyect.DM;
using _420BytesProyect.DT.Dispositivo;
using _420BytesProyect.DT.Usuario;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _420BytesProyect.BM.General
{
    public class BMDispositivo : IBMDispositivos
    {

        private readonly IConexionBD conexionBD;
        private readonly ILogger<IBMDispositivos> logger;
        public BMDispositivo(IConexionBD conexionBD, ILogger<IBMDispositivos> logger)
        {
            this.conexionBD = conexionBD;
            this.logger = logger;
        }

        public async Task<List<Dispositivo>> ConsultarDispositivos()
        {
            try
            {
                var Dispositivos = await conexionBD.QueryAsync<Dispositivo>("Dispositivo.SP_ConsultarDispositivo");
                return Dispositivos.ToList();
            }
            catch (Exception ex)
            {
                logger.LogError($"Clase: {GetType().Name}, Metodo: {MethodBase.GetCurrentMethod()?.DeclaringType?.Name}, Tipo: {ex.GetType()}, Error: {ex.Message}");
                return new List<Dispositivo>();
            }
        }
    }
}
