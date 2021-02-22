using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetsAlone.Core.Domain
{
    // pet class
    public class Pet : IAuditEntity
    {
        [Key]
        // the id
        public int Id { get; set; }

        // the name
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
        
        // type
        public int PetType { get; set; } // 1 = Cat, 2 = Dog, 3 = Hamster, 4 = Bird, 5 = Rabbit, 6 = Fish, 7 = Lizard, 8 = Horse, 9 = Gerbil, 10 = Tortoise
        
        // missing since
        public DateTime MissingSince { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public DateTime ModifiedOn { get; set; } = DateTime.Now;

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }
    }
}