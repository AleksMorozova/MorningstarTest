using Dapper;
using Npgsql;

namespace ServiceLibrary.Repositories
{
    public class ExchangeRepository
    {
        public Exchange? GetById(int Id) // static?
        {
            using var connection = new NpgsqlConnection(DBConstant.ConnString);
            connection.Open();
            const string sql = "SELECT Id, Name FROM exchanges WHERE Id = @Id";
            var result = connection.QuerySingleOrDefaultAsync<Exchange>(sql, new { Id }).Result; // simplify? .Result?

            return result;
        }
    }
}