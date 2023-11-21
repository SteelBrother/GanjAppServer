using _420BytesProyect.BM.Identity.Interfaces;
using _420BytesProyect.DM;
using _420BytesProyect.DT.Identity;
using _420BytesProyect.DT.Usuario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace _420BytesProyect.BM.Identity
{
    public class BMIdentity : IBMIdentity
    {
        private readonly string pass = "9a0fbc8f";
        private readonly IConexionBD ConexionBD;
        private readonly IConfiguration Configuration;
        private readonly GeneradorPassword GeneradorPassword;
        private readonly ILogger<IBMIdentity> logger;
        public BMIdentity(IConfiguration Configuration
            , IConexionBD ConexionBD
            , GeneradorPassword GeneradorPassword
            , ILogger<IBMIdentity> logger)
        {
            this.ConexionBD = ConexionBD;
            this.Configuration = Configuration;
            this.GeneradorPassword = GeneradorPassword;
            this.logger = logger;

        }


        public async Task<ActionResult<UserToken?>?> Login(UserInfo userInfo)
        {
            try
            {
                //var nuevaContrasenaAleatoria = GenerarContraseña();
                var Password = GeneradorPassword.Encriptar(userInfo.Password ?? "", Configuration["420ByteskeyBase"]);
                var Respuesta = await ConexionBD.QueryFirstAsync<Usuario>("Usuario.SP_Login", new { userInfo.NickName, Password });
                if (Respuesta == null)
                {
                    return null;
                }
                else
                {
                    JwtDTO jwtDTO = new()
                    {
                        Cedula = Respuesta?.UsuarioID.ToString(),
                        NombreUsuario = Respuesta?.NickName?.ToString(),
                    };

                    return BuildToken(jwtDTO);
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Clase: {GetType().Name}, Metodo: {MethodBase.GetCurrentMethod()?.DeclaringType?.Name}, Tipo: {ex.GetType()}, Error: {ex.Message}");
            }
            return null;
        }

        public async Task RestablecerContraseña(int CompaniaId)
        {
            try
            {
                //var Clientes = await ConexionBD.QueryAsync<DT.Entidades.Cliente>("SP_ConsultarClientesPorCompania", new { CompaniaId, NitFijo = 0 });
                //foreach (var cliente in Clientes)
                //{
                //    var nuevaContrasenaAleatoria = GenerarContraseña();
                //    OlvidoContraseñaDTO OlvidoContraseñaDTO = new()
                //    {
                //        CedulaCiudadania = cliente.Nit,
                //        CompaniaId = CompaniaId,
                //        NombreUsuario = cliente.Correo,
                //        NuevaContrasena = nuevaContrasenaAleatoria,

                //    };
                //    OlvidoContraseñaDTO.NuevaContrasena = GeneradorPassword.Encriptar(nuevaContrasenaAleatoria, Configuration["PEDWEBkeyBase"]);
                //    var respuestaCambiarContraseñaDTO = await ConexionBD.QueryFirstAsync<RespuestaCambiarContraseñaDTO>("SP_OlvidoContrasena", OlvidoContraseñaDTO);
                //    if (respuestaCambiarContraseñaDTO != null)
                //        if (respuestaCambiarContraseñaDTO.Validacion == "OK")
                //        {
                //            respuestaCambiarContraseñaDTO.CompaniaId = CompaniaId;
                //            await BMEnvioEmail.EnviarEmailOlvidoContrasena(respuestaCambiarContraseñaDTO, nuevaContrasenaAleatoria);
                //        }
                //}
            }
            catch (Exception ex)
            {
                logger.LogError($"Ha ocurrido un {GetType().Name}/{MethodBase.GetCurrentMethod().DeclaringType.Name}: {ex.Message}");
            }
        }

        public async Task<RespuestaCambiarContraseñaDTO> OlvidoContrasena(OlvidoContraseñaDTO olvidoContraseñaDTO)
        {
            try
            {
                var nuevaContrasenaAleatoria = GenerarContraseña();
                olvidoContraseñaDTO.NuevaContrasena = GeneradorPassword.Encriptar(nuevaContrasenaAleatoria, Configuration["420ByteskeyBase"]);
                var respuestaCambiarContraseñaDTO = await ConexionBD.QueryFirstAsync<RespuestaCambiarContraseñaDTO>("SP_OlvidoContrasena", olvidoContraseñaDTO);
                if (respuestaCambiarContraseñaDTO != null)
                    if (respuestaCambiarContraseñaDTO.Validacion == "OK")
                    {
                        var x = true;
                    }
                return respuestaCambiarContraseñaDTO;
            }
            catch (Exception ex)
            {
                logger.LogError($"Ha ocurrido un {GetType().Name}/{MethodBase.GetCurrentMethod().DeclaringType.Name}: {ex.Message}");
            }
            return null;
        }

        private static string GenerarContraseña()
        {
            var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var Charsarr = new char[8];
            var random = new Random();

            for (int i = 0; i < Charsarr.Length; i++)
            {
                Charsarr[i] = characters[random.Next(characters.Length)];
            }

            return new string(Charsarr);
        }

        public async Task<ActionResult<UserToken>> RenovarToken(int UsuarioId, int TipoIngresoId, int CompaniaId)
        {
            try
            {
                /*var JwtDTO = await DMDTOs.ConsultarUsuarioJWT(UsuarioId, TipoIngresoId, CompaniaId)*/
                ;
                var JwtDTO = new JwtDTO();
                if (JwtDTO != null)
                {
                    return BuildToken(JwtDTO);
                }

            }
            catch (Exception ex)
            {
                logger.LogError($"Clase: {GetType().Name}, Metodo: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Tipo: {ex.GetType()}, Error: {ex.Message}");
            }
            return null;
        }

        public async Task<ActionResult<CambioContrasena>> ValidarCambioContrasena(string Id, string TipoIngresoId)
        {
            try
            {
                var response = await ConexionBD.QueryFirstAsync<CambioContrasena>("SP_ValidarCambioContrasena", new { Id, TipoIngresoId });
                return response;

            }
            catch (Exception ex)
            {
                logger.LogError($"Clase: {GetType().Name}, Metodo: {MethodBase.GetCurrentMethod()?.DeclaringType?.Name}, Tipo: {ex.GetType()}, Error: {ex.Message}");
            }
            return null;
        }

        public async Task<ActionResult<bool>> ActualizarContrasena(CambioContrasena CambioContrasena)
        {
            try
            {
                CambioContrasena.Clave = GeneradorPassword.Encriptar(CambioContrasena.Clave, Configuration["PEDWEBkeyBase"]);
                var response = await ConexionBD.QueryFirstAsync<int>("SP_ActualizarContrasena", CambioContrasena);
                return response == 1 ? true : false;

            }
            catch (Exception ex)
            {
                logger.LogError($"Clase: {GetType().Name}, Metodo: {MethodBase.GetCurrentMethod()?.DeclaringType?.Name}, Tipo: {ex.GetType()}, Error: {ex.Message}");
            }
            return null;
        }
        private UserToken BuildToken(JwtDTO JwtDTO)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, JwtDTO.Id.ToString()),
                new Claim("Cedula", JwtDTO?.Cedula??""),
                new Claim(ClaimTypes.Name, JwtDTO?.NombreUsuario??""),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            if (JwtDTO?.RolesSeleccionados != null)
            {
                foreach (var rol in JwtDTO.RolesSeleccionados)
                {
                    claims.Add(new Claim(ClaimTypes.Role, rol.Id.ToString()));
                }
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["jwt:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var now = DateTime.UtcNow.AddDays(-1);
            var expiration = DateTime.UtcNow.AddMinutes(15);

            JwtSecurityToken token = new(
               issuer: null,
               audience: null,
               claims: claims,
               notBefore: now,
               expires: expiration,
               signingCredentials: creds);

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration,
                Cedula = JwtDTO?.Cedula,
                NickName = JwtDTO?.NombreUsuario,
                ValidacionIngreso = JwtDTO?.ValidacionIngreso
            };
        }
    }
}
