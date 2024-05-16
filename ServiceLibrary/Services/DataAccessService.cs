
using ServiceLibrary.DataAccess;
using System.Diagnostics.Metrics;
using System.Diagnostics;

namespace ServiceLibrary.Services;

public class DataAccessService : IDataAccessService
{
    public async Task AddInstrumentPriceAsync(int instrumentId, double price)
    {
        await InstrumentDataAccess.AddInstrumentPriceAsync(instrumentId, price, DBConstant.ConnString);
    }

    public (int id, string micCodes) GetExchange(int exchangeId)
    {
        return ExchangeDataAccess.GetExchange(exchangeId);
    }

    public async Task<int> GetInstrumentId(InstrumentType type, string name, string[] symbols, int exchangeId)
    {
        return await InstrumentDataAccess.GetInstrumentId(type, name, symbols, exchangeId);
    }
}
