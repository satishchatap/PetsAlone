namespace PetsAlone.Mvc.Controllers.EditPet
{
    using PetsAlone.Mvc.Models;
    using System.ComponentModel.DataAnnotations;
    /// <summary>
    /// Response for Edit 
    /// </summary>
    public sealed class EditPetResponse
    {
        /// <summary>
        /// Pet
        /// </summary>
        [Required]
        public PetViewModel Pet { get; }
        /// <summary>
        /// Response for Edit Constuctor
        /// </summary>
        /// <param name="petViewModel"></param>
        public EditPetResponse(PetViewModel petViewModel)
        {
            this.Pet = petViewModel;
        }
    }
}
