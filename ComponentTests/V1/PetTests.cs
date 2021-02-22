namespace ComponentTests.V1
{
    using HtmlAgilityPack;
    using System.Linq;
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xunit;
    [Collection("Web Collection")]
    public sealed class PetTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactoryFixture _fixture;
        public PetTests(CustomWebApplicationFactoryFixture fixture) => this._fixture = fixture;
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
                .Where(x => x.Attributes["class"].Value == "card m-3");
            Assert.Equal(3, nodes.Count());
            //TODO: Get Value Id
            return new Tuple<Guid, string>(new Guid("4C510CFE-5D61-4A46-A3D9-C4313426655F"), "Max");
        }

        private async Task<Tuple<Guid, string>> GetPet(string petId)
        {
            string actualResponseString = await Client
                .GetStringAsync($"/Pets/Details/{petId}")
                .ConfigureAwait(false);
            //TODO: Get Value Id
            return new Tuple<Guid, string>(new Guid("4C510CFE-5D61-4A46-A3D9-C4313426655F"), "Max");
        }



        [Fact]
        public async Task GetPet_Delete()
        {
            Tuple<Guid, string> pet = await this.GetPets()
                .ConfigureAwait(false);

            await this.GetPet(pet.Item1.ToString())
                .ConfigureAwait(false);

            pet = await this.GetPets()
                .ConfigureAwait(false);
        }
    }
}
