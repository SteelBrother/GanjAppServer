using Insight.Database;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _420BytesProyect.DM.DataBase
{
    public class ConexionInsightDB : IConexionBD
    {
        private readonly IConfiguration configuration;
        public ConexionInsightDB(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<IList<T>> QueryAsync<T>(string NombreSP, object Parametros = null)
        {
            var connection = new SqlConnection(configuration.GetConnectionString("420ConnectionString"));
            IList<T> result = await connection.QueryAsync<T>(NombreSP, Parametros);
            return result;
        }
        public async Task<T> QueryFirstAsync<T>(string NombreSP, object Parametros = null)
        {
            try
            {
                var connection = new SqlConnection(configuration.GetConnectionString("420ConnectionString"));
                var result = await connection.QueryAsync<T>(NombreSP, Parametros);
                if (result.Count != 0)
                {
                    return result.First();
                }
                return default;
            }
            catch (Exception ex)
            {

                var x =  $"{ex.Message} mensaje";
                return default;
            }
           
        }

        public async Task<T> InsertAsync<T>(string NombreSP, T Entidad)
        {
            string t = JsonSerializer.Serialize(Entidad);
            var connection = new SqlConnection(configuration.GetConnectionString("420ConnectionString"));
            var res = await connection.InsertAsync<T>(NombreSP, Entidad);
            return res;
        }

        public async Task<int> ExecuteAsync<T>(string NombreSP, T Entidad)
        {
            var connection = new SqlConnection(configuration.GetConnectionString("420ConnectionString"));
            var res = await connection.ExecuteAsync(NombreSP, Entidad);
            return res;
        }
    }
}
