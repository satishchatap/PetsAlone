using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetsAlone.Mvc.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetsAlone.Mvc.Models
{
    public class PetViewModel
    {
        
        // the id
        public Guid Id { get; set; }

        // the name
        [Required]
        [MaxLength(50)]
        [RegularExpression("^[A-Za-z]+$")]
        public string Name { get; set; } = string.Empty;

        // type
        [Required]
        [Range(1,10)]
        public int PetType { get; set; } // 1 = Cat, 2 = Dog, 3 = Hamster, 4 = Bird, 5 = Rabbit, 6 = Fish, 7 = Lizard, 8 = Horse, 9 = Gerbil, 10 = Tortoise

        // missing since
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DateValidator]
        public DateTime MissingSince { get; set; } = DateTime.Now;

        public string? PhotoPath { get; set; } 
        public IFormFile Photo { get; set; }
        public bool Notify { get; set; }
        /// <summary>
        ///  TODO: move to DB
        /// </summary>
        public IEnumerable<SelectListItem> PetTypes { get {
                return new List<SelectListItem>() {
                new SelectListItem( "Cat","1"),
                new SelectListItem( "Dog","2"),
                new SelectListItem( "Hamster","3" ),
                new SelectListItem( "Bird","4"),
                new SelectListItem( "Rabbit","5"),
                new SelectListItem( "Fish","6"),
                new SelectListItem( "Lizard","7"),
                new SelectListItem( "Horse","8"),
                new SelectListItem( "Gerbil","9"),
                new SelectListItem( "Tortoise","10")
            };
            } }


    }
}
