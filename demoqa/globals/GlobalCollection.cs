using Xunit;

namespace demoqa.globals
{
    [CollectionDefinition("Global collection")]
    public class GlobalCollection : ICollectionFixture<TestFixture>
    {
    }
}
