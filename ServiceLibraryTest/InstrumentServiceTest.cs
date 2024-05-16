using Moq;
using ServiceLibrary.Services;
using ServiceLibrary;

namespace ServiceLibraryTest;

public class InstrumentServiceTest
{
    Mock<IPriceService> priceService;
    Mock<IDataAccessService> dataAccessService;

    [SetUp]
    public void Setup()
    {
        priceService = new Mock<IPriceService>();
        dataAccessService = new Mock<IDataAccessService>();
    }

    [Test]
    public void ShouldAddPrice()
    {
        priceService.Setup(h => h.GetPrice(It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(7.7);
        dataAccessService.Setup(h => h.GetExchange(It.IsAny<int>())).Returns((7, ""));
        dataAccessService.Setup(h => h.GetInstrumentId(It.IsAny<InstrumentType>(), It.IsAny<string>(), It.IsAny<string[]>(), It.IsAny<int>())).ReturnsAsync(7);

        var service = new InstrumentService(priceService.Object, dataAccessService.Object);
        service.AddPriceSnapshot(InstrumentType.Equity, "Apple", new string[] { "AAPL" }, 1);
        dataAccessService.Verify(p => p.AddInstrumentPriceAsync(7, 7.7), Times.Once());
    }
}
