using ServiceLibrary.Services;

namespace ServiceLibrary
{
    public class InstrumentService
    {
        IPriceService _priceService;
        IDataAccessService _dataAccessService;

        public InstrumentService(IPriceService priceService, IDataAccessService dataAccessService)
        {
            _priceService = priceService;
            _dataAccessService = dataAccessService;
        }


        public async Task AddPriceSnapshot(InstrumentType type, string name, string[] symbols, int exchangeId)
        {
            PriceSnapshotValidator.Validate(name, symbols);

            var instrumentId = await _dataAccessService.GetInstrumentId(type, name, symbols, exchangeId);
            
            var (id, micCodes) = _dataAccessService.GetExchange(exchangeId);

            var price = await _priceService.GetPrice(micCodes, instrumentId);

            await _dataAccessService.AddInstrumentPriceAsync(instrumentId, price);
        }
    }
}