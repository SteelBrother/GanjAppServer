using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _420BytesProyect.DT.Identity;
using _420BytesProyect.DT.Usuario;
using Microsoft.AspNetCore.Mvc;


namespace _420BytesProyect.BM.Identity.Interfaces
{
    public interface IBMIdentity
    {
        Task<ActionResult<UserToken?>?> Login(UserInfo userInfo);
        Task<ActionResult<CambioContrasena>> ValidarCambioContrasena(string Id, string TipoIngresoId);
        Task<ActionResult<bool>> ActualizarContrasena(CambioContrasena CambioContrasena);
        Task<ActionResult<UserToken>> RenovarToken(int UsuarioId, int TipoIngresoId, int CompaniaId);
        Task<RespuestaCambiarContraseñaDTO> OlvidoContrasena(OlvidoContraseñaDTO olvidoContraseñaDTO);
        Task RestablecerContraseña(int CompaniaId);
    }
}
