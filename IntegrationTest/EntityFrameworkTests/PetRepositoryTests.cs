

namespace IntegrationTests.EntityFrameworkTests
{
    using Domain;
    using Domain.ValueObjects;
    using Infrastructure.DataAccess.Repositories;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;
    public sealed class PetRepositoryTests : IClassFixture<StandardFixture>
    {
        private readonly StandardFixture _fixture;
        public PetRepositoryTests(StandardFixture fixture) => this._fixture = fixture;

        [Fact]
        public async Task Add()
        {
            PetRepository petRepository = new PetRepository(this._fixture.Context);

            Pet pet = new Pet(
                Guid.NewGuid(),
                "My Cut Pet", 1, DateTime.Now
            );

            await petRepository
               .Add(pet)
               .ConfigureAwait(false);


            await this._fixture
                .Context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            bool hasAnyPet = this._fixture
                .Context
                .Pets
                .Any(e => e.Id == pet.Id);


            Assert.True(hasAnyPet );
        }

        [Fact]
        public async Task Delete()
        {
            PetRepository petRepository = new PetRepository(this._fixture.Context);

            Pet pet = new Pet(
                Guid.NewGuid(),
                "My Cut Pet", 1, DateTime.Now
            );


            await petRepository
               .Add(pet)
               .ConfigureAwait(false);


            await this._fixture
                .Context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            petRepository
                .Delete(pet.Id);

            await this._fixture
                .Context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            bool hasAnyPet = this._fixture
                .Context
                .Pets
                .Any(e => e.Id == pet.Id);

            Assert.False(hasAnyPet );
        }
    }
}
