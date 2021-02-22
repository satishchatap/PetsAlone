using System;

namespace Infrastructure.DataAccess.Repositories
{
    using Domain;
    using Domain.ValueObjects;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <inheritdoc />
    public sealed class PetRepositoryFake : IPetRepository
    {
        private readonly DataContextFake _context;

        /// <summary>
        /// </summary>
        /// <param name="context"></param>
        public PetRepositoryFake(DataContextFake context) => this._context = context;

        /// <inheritdoc />
       
        public async Task Add(Pet pet)
        {
            this._context
               .Pets
               .Add(pet);

            await Task.CompletedTask
                .ConfigureAwait(false);
        }
        public async Task Update(Pet pet)
        {
            this._context
               .Pets
               .Add(pet);

            await Task.CompletedTask
                .ConfigureAwait(false);
        }
       


        /// <inheritdoc />
        public async Task<IPet> Get(Guid petId)
        {
            Pet pet = this._context
                .Pets
                .SingleOrDefault(e => e.Id.Equals(petId));

            if (pet == null)
            {
                return PetNull.Instance;
            }

            return await Task.FromResult(pet)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<IList<Pet>> GetPets(string createdBy)
        {
            List<Pet> pets = this._context
                .Pets
                .Where(e => e.CreatedBy == createdBy)
                .ToList();

            return await Task.FromResult(pets)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<IList<Pet>> GetAll(int petType=0)
        {
            List<Pet> pets = this._context
                .Pets.Where(p => p.PetType == (petType > 0 ? petType : p.PetType))
                .ToList();

            return await Task.FromResult(pets)
                .ConfigureAwait(false);
        }

        public void Delete(Guid petId)
        {
            this._context.Pets.Remove(this._context.Pets.First(a => a.Id == petId));
        }
    }
}
