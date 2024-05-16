namespace ServiceLibrary.Services;

public interface IDataAccessService
{
    Task<int> GetInstrumentId(InstrumentType type, string name, string[] symbols, int exchangeId);

    Task AddInstrumentPriceAsync(int instrumentId, double price);

    (int id, string micCodes) GetExchange(int exchangeId);
}
