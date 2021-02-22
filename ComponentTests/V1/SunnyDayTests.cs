namespace ComponentTests.V2
{
    using HtmlAgilityPack;
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xunit;
    /// <summary>
    /// Happy Path
    /// </summary>
    /// 
    [Collection("Web Collection")]
    public sealed class SunnyDayTests : IClassFixture<CustomWebApplicationFactory>
    {

        private readonly CustomWebApplicationFactoryFixture _fixture;
        public SunnyDayTests(CustomWebApplicationFactoryFixture fixture) => this._fixture = fixture;
        HttpClient Client => _fixture
                .CustomWebApplicationFactory.CreateClient();
        private async Task<Tuple<Guid, string>> GetPets()
        {
           
            HttpResponseMessage actualResponse = await Client
                .GetAsync("/Pets/")
                .ConfigureAwait(false);

            string actualResponseString = await actualResponse.Content
                .ReadAsStringAsync()
                .ConfigureAwait(false);

            //TODO: Webscrap to check data
            var doc = new HtmlDocument();
            doc.LoadHtml(actualResponseString);
            var nodes = doc.DocumentNode.Descendants("div")
                .Where(x => x.Attributes["class"].Value == "card m-3").Count();
            Assert.Equal(3, nodes);

            //TODO: Get Value Id
            return new Tuple<Guid, string>(new Guid("4C510CFE-5D61-4A46-A3D9-C4313426655F"), "Max");
        }

        private async Task<HttpResponseMessage> GetPet(string petId)
        {
            
            HttpResponseMessage actualResponse = await Client.GetAsync($"/Pets/Details/{petId}")
                .ConfigureAwait(false);
            return actualResponse;
        }

        [Fact]
        public async Task GetPets_GetPet()
        {
            Tuple<Guid, string> pet = await this.GetPets()
                .ConfigureAwait(false);

            HttpResponseMessage actualResponse = await this.GetPet(pet.Item1.ToString())
                .ConfigureAwait(false);

            Assert.Equal(HttpStatusCode.OK, actualResponse.StatusCode);
        }
    }
}
