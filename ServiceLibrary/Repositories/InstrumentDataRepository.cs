using Dapper;
using Npgsql;
using System.Data;

namespace ServiceLibrary.Repositories
{
    public class InstrumentDataRepository
    {
        public async Task<int> GetInstrumentIdAsync(string name, int exchangeId, InstrumentType type)
        {
            using var connection = new NpgsqlConnection(DBConstant.ConnString);
            connection.Open();
            const string sql = "SELECT Id FROM instruments WHERE Name = @name AND ExchangeId = @exchangeId AND Type = @type";
            var result = await connection.QuerySingleOrDefaultAsync<int>(sql, new { name, exchangeId, type });
            return result;
        }

        public async Task AddInstrumentAsync(InstrumentType type, string name, string[] symbols, int exchangeId)
        {
            using var connection = new NpgsqlConnection(DBConstant.ConnString);
            connection.Open();
            await connection.ExecuteAsync("AddInstrument", new { type, name, symbols, exchangeId }, commandType: CommandType.StoredProcedure);
        }

        public async Task AddInstrumentPriceAsync(int instrumentId, double price)
        {
            using var connection = new NpgsqlConnection(DBConstant.ConnString);
            connection.Open();
            await connection.ExecuteAsync("AddInstrumentPrice", new { instrumentId, price }, commandType: CommandType.StoredProcedure);
        }
    }
}
