

namespace PetsAlone.Mvc.Controllers.GetPet
{
    using Models;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    ///     Get Pets Response.
    /// </summary>
    public sealed class GetPetResponse
    {
        /// <summary>
        ///     The Get Pets Response constructor.
        /// </summary>
        public GetPetResponse(PetViewModel pets)
        {
            Pet =pets;
        }

        /// <summary>
        ///     Pets
        /// </summary>
        [Required]
        public PetViewModel Pet { get; } = new PetViewModel();
    }
}
