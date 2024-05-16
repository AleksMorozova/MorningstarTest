using Moq;
using ServiceLibrary;
using ServiceLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLibraryTest;

public class InstrumentServiceTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ShouldThrowArgumentNullException()
    {
        var service = new InstrumentService(new Mock<IPriceService>().Object, new Mock<IDataAccessService>().Object);
        Assert.ThrowsAsync<ArgumentNullException>(() => service.AddPriceSnapshot(InstrumentType.Future, null, ["a", "b", "c"], 1));
    }

    [Test]
    public void ShouldThrowException()
    {
        var service = new InstrumentService(new Mock<IPriceService>().Object, new Mock<IDataAccessService>().Object);
        Assert.ThrowsAsync<Exception>(() => service.AddPriceSnapshot(InstrumentType.Future, "test", ["APLT", "b", "c"], 1));
    }
}
