namespace ComponentTests
{
    using Xunit;

    [CollectionDefinition("Web Collection")]
    public sealed class CustomWebApplicationFactoryCollection : ICollectionFixture<CustomWebApplicationFactoryFixture>
    {
    }
}
