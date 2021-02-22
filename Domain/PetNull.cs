using Domain.ValueObjects;
using System;

namespace Domain
{
    public sealed class PetNull : IPet
    {
        public static PetNull Instance { get; } = new PetNull();

        // the id
        public Guid Id { get; set; }

        // the name
        public string Name { get; set; } = string.Empty;

        // type
        public int PetType { get; set; } // 1 = Cat, 2 = Dog, 3 = Hamster, 4 = Bird, 5 = Rabbit, 6 = Fish, 7 = Lizard, 8 = Horse, 9 = Gerbil, 10 = Tortoise

        // missing since
        public DateTime MissingSince { get; set; }

        public string PhotoPath { get; set; } =null;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public DateTime ModifiedOn { get; set; } = DateTime.Now;

        public string CreatedBy { get; set; } = string.Empty;

        public string ModifiedBy { get; set; } = string.Empty;

        public byte[] RowVersion { get; }
    }
}
