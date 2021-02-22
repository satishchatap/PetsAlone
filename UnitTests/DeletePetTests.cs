namespace UnitTests.DeletePet
{
    using Domain;
    using Domain.ValueObjects;
    using Infrastructure;
    using Infrastructure.DataAccess.Repositories;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public sealed class DeletePetTests : IClassFixture<StandardFixture>
    {
        private readonly StandardFixture _fixture;
        public DeletePetTests(StandardFixture fixture) => this._fixture = fixture;

        [Fact]
        public async Task DeletePet()
        {
            Pet pet = new Pet(SeedData.DefaultPetId,
                "Foxxy",1, SeedData.DefaultPetMissingSince, ""
            );

            await this._fixture.PetRepository
               .Add(pet)
               .ConfigureAwait(false);

            await this._fixture.UnitOfWork.Save()
               .ConfigureAwait(false);

            bool hasAnyPet = this._fixture
                .Context
                .Pets
                .Any(e => e.Id == pet.Id);

            Assert.True(hasAnyPet);

            var petDelete = this._fixture
               .Context
               .Pets
               .First(e => e.Id == pet.Id);

            var actual = this._fixture.Context.Pets.Remove(petDelete);

            Assert.True(actual!=null);
        }


    }
}
