namespace ComponentTests.V1
{
    using HtmlAgilityPack;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xunit;

    [Collection("Web Collection")]
    public sealed class GetPetsTests
    {
        private readonly CustomWebApplicationFactoryFixture _fixture;
        public GetPetsTests(CustomWebApplicationFactoryFixture fixture) => this._fixture = fixture;
        HttpClient Client => _fixture
                .CustomWebApplicationFactory.CreateClient();
        [Fact]
        public async Task GetPetsReturnsList()
        {
            HttpClient client = this._fixture
                .CustomWebApplicationFactory
                .CreateClient();

            HttpResponseMessage actualResponse = await client
                .GetAsync("/Pets/")
                .ConfigureAwait(false);

            string actualResponseString = await actualResponse.Content
                .ReadAsStringAsync()
                .ConfigureAwait(false);

            Assert.Equal(HttpStatusCode.OK, actualResponse.StatusCode);
            //TODO: Webscrap to check data
            var doc = new HtmlDocument();
            doc.LoadHtml(actualResponseString);
            var nodes = doc.DocumentNode.Descendants("div")
                .Where(x => x.Attributes["class"].Value == "card m-3");
            Assert.Equal(3, nodes.Count());
        }

    }
}
