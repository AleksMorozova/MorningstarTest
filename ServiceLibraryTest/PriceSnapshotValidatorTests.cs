using ServiceLibrary;

namespace ServiceLibraryTest;

public class PriceSnapshotValidatorTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ShouldNotThrowArgumentNullException()
    {
        Assert.DoesNotThrow(() => PriceSnapshotValidator.Validate("test", ["a", "b", "c"]));
    }

    [Test]
    public void ShouldThrowArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => PriceSnapshotValidator.Validate(null, ["a", "b", "c"]));
    }

    [Test]
    public void ShouldThrowException()
    {
        Assert.Throws<Exception>(() => PriceSnapshotValidator.Validate("test", ["APLT", "b", "c"]));
    }
}