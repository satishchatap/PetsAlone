using Domain;
using Domain.ValueObjects;
using System;

namespace Infrastructure
{
    public sealed class EntityFactory : IPetFactory
    {
        /// <inheritdoc />
        public Pet NewPet(string name, int type, DateTime missingSince,string photoPath)
            => new Pet(Guid.NewGuid(),  name, type, missingSince, photoPath);
    }
}
