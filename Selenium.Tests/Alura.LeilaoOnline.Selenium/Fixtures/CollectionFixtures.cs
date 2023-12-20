using Xunit;

namespace Alura.LeilaoOnline.Selenium.Fixtures
{
    [CollectionDefinition("ChromeDriver")]
    public class CollectionFixtures : ICollectionFixture<TestFixtures>
    {
    }
}