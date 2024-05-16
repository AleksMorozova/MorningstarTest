using ServiceLibrary.Repositories;

namespace ServiceLibrary.DataAccess
{
    /*
     * You MUST NOT make this class and it's members non-static.
     */
    public static class InstrumentDataAccess
    {
        public static async Task<int> GetInstrumentId(InstrumentType type, string name, string[] symbols, int exchangeId)
        {
            var instrumentId = await GetInstrumentIdAsync(name, exchangeId, type, DBConstant.ConnString).ConfigureAwait(false);

            if (instrumentId == 0)
            {
                AddInstrumentAsync(type, name, symbols, exchangeId, DBConstant.ConnString).Wait();
                instrumentId = await GetInstrumentIdAsync(name, exchangeId, type, DBConstant.ConnString);
            }
            return instrumentId;
        }

        public static async Task<int> GetInstrumentIdAsync(string name, int exchangeId, InstrumentType type, string connectionString)
        {
            var instrumentDataRepository = new InstrumentDataRepository();

            return await instrumentDataRepository.GetInstrumentIdAsync(name, exchangeId, type);
        }

        public static async Task AddInstrumentAsync(InstrumentType type, string name, string[] symbols, int exchangeId, string connectionString)
        {
            var instrumentDataRepository = new InstrumentDataRepository();

            await instrumentDataRepository.AddInstrumentAsync(type, name, symbols, exchangeId);
        }

        public static async Task AddInstrumentPriceAsync(int instrumentId, double price, string connectionString)
        {
            var instrumentDataRepository = new InstrumentDataRepository();

            await instrumentDataRepository.AddInstrumentPriceAsync(instrumentId, price);
        }
    }

}