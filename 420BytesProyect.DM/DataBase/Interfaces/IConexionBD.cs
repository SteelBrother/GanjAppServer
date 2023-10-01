using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420BytesProyect.DM
{
    public interface IConexionBD
    {
        Task<int> ExecuteAsync<T>(string NombreSP, T Entidad);
        Task<T> InsertAsync<T>(string NombreSP, T Entidad);
        Task<T> QueryFirstAsync<T>(string NombreSP, object Parametros = null);
        Task<IList<T>> QueryAsync<T>(string NombreSP, object Parametros = null);
    }
}
