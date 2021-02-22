namespace PetsAlone.Mvc.Controllers.CreatePet
{
    using Models;
    using System.ComponentModel.DataAnnotations;
    /// <summary>
    /// Response for Create 
    /// </summary>
    public sealed class CreatePetResponse
    {
        /// <summary>
        /// Pet
        /// </summary>
        [Required]
        public PetViewModel Pet { get; }
        /// <summary>
        /// Response for Create Constuctor
        /// </summary>
        /// <param name="petModel"></param>
        public CreatePetResponse(PetViewModel petModel)
        {
            this.Pet = petModel;
        }
    }
}
