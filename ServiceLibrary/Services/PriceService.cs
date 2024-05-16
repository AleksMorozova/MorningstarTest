namespace ServiceLibrary.Services;

public class PriceService : IPriceService
{
    public async Task<double> GetPrice(string micCodes, int instrumentId)
    {
        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("https://api.exchanges.morningstar.com");
        var response = httpClient.GetAsync($"/{micCodes}/{instrumentId}/price").Result;
        var priceAsString = await response.Content.ReadAsStringAsync();
        var price = double.Parse(priceAsString);

        return price;
    }
}
