using _420BytesProyect.BM.General.Interfaces;
using _420BytesProyect.BM.HubMsj;
using _420BytesProyect.DM;
using _420BytesProyect.DT.Usuario;
using Microsoft.AspNetCore.SignalR;
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
    public class BMUsuarios :IBMUsuarios
    {
        private readonly IConexionBD conexionBD;
        private readonly ILogger<IBMUsuarios> logger;
        //private readonly UserUpdatesHub UsuarioHub;
        private readonly IHubContext<UserUpdatesHub> UsuarioHub;
        public BMUsuarios(IConexionBD conexionBD, ILogger<IBMUsuarios> logger, IHubContext<UserUpdatesHub> UsuarioHub)
        {
            this.conexionBD = conexionBD;
            this.logger = logger;
            this.UsuarioHub = UsuarioHub;

        }

        public async Task<List<Usuario>> ConsultaUsuarios()
        {
            try
            {
                var usuarios = await conexionBD.QueryAsync<Usuario>("Usuario.TraerUsuarios");
                if (usuarios != null)
                {
                    await UsuarioHub.Clients.All.SendAsync("UsuariosActualizados", usuarios);
                    return usuarios.ToList();
                }
                return new List<Usuario>();
            }
            catch (Exception ex)
            {
                logger.LogError($"Clase: {GetType().Name}, Metodo: {MethodBase.GetCurrentMethod()?.DeclaringType?.Name}, Tipo: {ex.GetType()}, Error: {ex.Message}");
                return new List<Usuario>();
            }
        }

        public async Task<Usuario> ConsultarUsuarioPorCedula(int Cedula)
        {
            try
            {
                var usuario = await conexionBD.QueryFirstAsync<Usuario>("Usuario.TraerUsuarioPorCedula" , new {Cedula});
                return usuario;
            }
            catch (Exception ex)
            {
                logger.LogError($"Clase: {GetType().Name}, Metodo: {MethodBase.GetCurrentMethod()?.DeclaringType?.Name}, Tipo: {ex.GetType()}, Error: {ex.Message}");
                return new Usuario() ;
            }
        }

        public async Task<bool> RegistrarUsuario(Usuario usuario)
        {
            try
            {
                var Respuesta = await conexionBD.QueryFirstAsync<bool>("Usuario.SP_RegistrarUsuario", new { Usuario = JsonSerializer.Serialize(usuario) });
                return Respuesta;
            }
            catch (Exception ex)
            {
                logger.LogError($"Clase: {GetType().Name}, Metodo: {MethodBase.GetCurrentMethod()?.DeclaringType?.Name}, Tipo: {ex.GetType()}, Error: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> ActualizarUsuario(Usuario Usuario)
        {
            try
            {
                var Respuesta = await conexionBD.QueryFirstAsync<bool>("Usuario.SP_ActualizarUsuario", new { Usuario = JsonSerializer.Serialize(Usuario) }); ;
                return Respuesta;
            }
           catch (Exception ex)
            {
                logger.LogError($"Clase: {GetType().Name}, Metodo: {MethodBase.GetCurrentMethod()?.DeclaringType?.Name}, Tipo: {ex.GetType()}, Error: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> BorrarUsuario(int Cedula)
        {
            try
            {
                var Respuesta = await conexionBD.QueryFirstAsync<bool>("Usuario.SP_BorrarUsuario", new {Cedula});
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
