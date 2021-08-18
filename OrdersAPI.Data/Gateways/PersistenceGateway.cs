using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace OrdersAPI.Data.Gateways
{
    public class PersistenceGateway
    {
        protected readonly string _connectionString;
        public PersistenceGateway(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected async Task<IEnumerable<T>> Get<T>(string query)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<T>(query);
            }
        }

        protected async Task<T> GetFirstOrDefault<T>(string query, DynamicParameters parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryFirstOrDefaultAsync<T>(query, parameters);
            }
        }

        protected async Task Insert(string storedProc, DynamicParameters parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                await connection.ExecuteAsync(storedProc, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        protected async Task Update(string storedProc, DynamicParameters parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                await connection.ExecuteAsync(storedProc, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}