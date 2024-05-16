
using ServiceLibrary.Repositories;

namespace ServiceLibrary.DataAccess
{
    public static class ExchangeDataAccess
    {
        public static (int id, string micCodes) GetExchange(int exchangeId)
        {
            var exchangeRepo = new ExchangeRepository();
            var (id, micCodes) = exchangeRepo.GetById(exchangeId);

            if (micCodes is null)
            {
                throw new Exception($" Cannot find exchange for id {exchangeId}");
            }

            return (id, micCodes);
        }
    }
}
