

namespace PetsAlone.Mvc.Controllers.GetAllPets
{
    using AutoMapper;
    using Domain;
    using Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    /// <summary>
    ///     Get Pets Response.
    /// </summary>
    public sealed class GetAllPetsResponse
    {
        /// <summary>
        ///     The Get Pets Response constructor.
        /// </summary>
        public GetAllPetsResponse(IEnumerable<PetViewModel> pets)
        {
            Pets =pets.ToList();
        }

        /// <summary>
        ///     Pets
        /// </summary>
        [Required]
        public List<PetViewModel> Pets { get; } = new List<PetViewModel>();
    }
}
