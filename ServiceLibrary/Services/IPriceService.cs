namespace ServiceLibrary.Services;

public interface IPriceService
{
    Task<double> GetPrice(string micCodes, int instrumentId);
}
