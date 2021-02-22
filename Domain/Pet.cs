using Domain.ValueObjects;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    // pet class
    [Table("Pets")]
    public class Pet : IPet
    {
       

        public Pet(string name, int petType, DateTime missingSince, string photoPath)
        {
            Name = name;
            PetType = petType;
            MissingSince = missingSince;
            PhotoPath = photoPath;
        }

        public Pet(Guid id, string name, int petType, DateTime missingSince, string photoPath=null)
        {
            Id = id;
            Name = name;
            PetType = petType;
            MissingSince = missingSince;
            PhotoPath = photoPath ?? PhotoPath;
        }

        [Key]
        // the id
        public Guid Id { get; set; }

        // the name
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; } = String.Empty;
        
        // type
        public int PetType { get; set; } // 1 = Cat, 2 = Dog, 3 = Hamster, 4 = Bird, 5 = Rabbit, 6 = Fish, 7 = Lizard, 8 = Horse, 9 = Gerbil, 10 = Tortoise
        
        // missing since
        public DateTime MissingSince { get; set; }

        public string? PhotoPath { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public DateTime ModifiedOn { get; set; } = DateTime.Now;

        public string CreatedBy { get; set; } = String.Empty;

        public string ModifiedBy { get; set; } = String.Empty;

    }
}