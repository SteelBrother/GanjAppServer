using _420BytesProyect.BM.General.Interfaces;
using _420BytesProyect.DM;
using _420BytesProyect.DT.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _420BytesProyect.BM.General
{
    public class BMUsuarios :IBMUsuarios
    {
        private readonly IConexionBD conexionBD;

        public BMUsuarios(IConexionBD conexionBD)
        {
            this.conexionBD = conexionBD;
        }

        public async Task<List<Usuario>> ConsultaUsuarios()
        {
            try
            {
                var usuarios = await conexionBD.QueryAsync<Usuario>("dbo.TraerUsuarios");
                return usuarios.ToList();
            }
            catch (Exception ex)
            {
                //logger.LogError($"Clase: {GetType().Name}, Metodo: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Tipo: {ex.GetType()}, Error: {ex.Message}");
                return null;
            }
        }

        public async Task<Usuario> TraerUsuarioXCedula(int Cedula)
        {
            try
            {
                var usuario = await conexionBD.QueryFirstAsync<Usuario>("dbo.TraerUsuarioXCedula" , new {Cedula});
                return usuario;
            }
            catch (Exception ex)
            {
                //logger.LogError($"Clase: {GetType().Name}, Metodo: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Tipo: {ex.GetType()}, Error: {ex.Message}");
                return null;
            }
        }
    }
}
