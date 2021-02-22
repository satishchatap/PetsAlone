using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetsAlone.Core.Domain
{
    public class PetType : IAuditEntity
    {
        [Key]
        // the id
        public int Id { get; set; }

        // the name
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; } = String.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public DateTime ModifiedOn { get; set; } = DateTime.Now;

        public string CreatedBy { get; set; } = String.Empty;

        public string ModifiedBy { get; set; } = String.Empty;
    }
}
