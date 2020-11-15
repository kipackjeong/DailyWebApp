using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoWebApp.Data
{
    public class SQLAccess : ISQLAccess
    {
        private IConfiguration _config;
        private string _connectionString { get; set; } = "ToDoApp"; // appsettings.json

        //ctor
        public SQLAccess(IConfiguration config)
        {
            // bring app's configuration
            _config = config;
        }

        // Load data from db
        public async Task<List<T>> LoadData<T, TU>(string sql, TU param)
        {
            //bring the connection string from appsettings.json
            var connectionString = _config.GetConnectionString(_connectionString);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                // NEED DAPPER TO QUERY
                // store data in to IEnumerable
                var data = await connection.QueryAsync<T>(sql, param);
                // return it as list
                return data.ToList();
            }
        }

        public async Task RunQuery<T>(string sql, T param)
        {
            var connectionString = _config.GetConnectionString(_connectionString);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                // same as loading except, it Executes Async and there is no return.
                await connection.ExecuteAsync(sql, param);
            }
        }
    }
}