namespace Infrastructure.DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain;
    using Domain.ValueObjects;
    using Microsoft.EntityFrameworkCore;

    /// <inheritdoc />
    public sealed class PetRepository :IPetRepository
    {
        private readonly DataContext _context;

        /// <summary>
        /// </summary>
        /// <param name="context"></param>
        public PetRepository(DataContext context) => this._context = context ??
                                                                          throw new ArgumentNullException(
                                                                              nameof(context));

        public void Delete(Guid petId)
        {
            this._context.Pets.Remove(this._context.Pets.First(a => a.Id == petId));
        }
        /// <inheritdoc />
        public async Task<IPet> Get(Guid PetId)
        {
            Pet Pet = await this._context
                .Pets
                .Where(e => e.Id == PetId)
                .Select(e => e)
                .SingleOrDefaultAsync()
                .ConfigureAwait(false);

            return PetNull.Instance;
        }


        public async Task<IPet> Find(Guid PetId, string createdBy)
        {
            Pet Pet = await this._context
                .Pets
                .Where(e => e.CreatedBy == createdBy && e.Id == PetId)
                .Select(e => e)
                .SingleOrDefaultAsync()
                .ConfigureAwait(false);

            if (Pet is Pet findPet)
            {
                return Pet;
            }

            return PetNull.Instance;
        }

        public async Task<IList<Pet>> GetPets(string createdBy)
        {
            List<Pet> Pets = await this._context
                .Pets
                .Where(e => e.CreatedBy == createdBy)
                .ToListAsync()
                .ConfigureAwait(false);
            return Pets;
        }
        public async Task<IList<Pet>> GetAll(int petType =0)
        {
            List<Pet> Pets = await this._context
                .Pets.Where(p => p.PetType == (petType > 0 ? petType : p.PetType))
                .ToListAsync()
                .ConfigureAwait(false);
            return Pets;
        }

       

        public async Task Add(Pet pet)
        {
            await this._context
                .Pets
                .AddAsync(pet)
                .ConfigureAwait(false);
        }
        public async Task Update(Pet pet)
        {
            await this._context
                .Pets
                .AddAsync(pet)
                .ConfigureAwait(false);
        }
    }
}