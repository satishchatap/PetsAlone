namespace Application.UseCases.CreatePet
{
   
     using Domain;

    /// <summary>
    /// </summary>
    public sealed class CreatePetPresenter : IOutputPort
    {
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public Pet? Pet { get; private set; }
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public bool InvalidOutput { get; private set; }
        public bool NotFoundOutput { get; private set; }
        public void Invalid(Pet pet) { this.InvalidOutput = true; this.Pet = pet; }
        public void NotFound() => this.NotFoundOutput = true;
        public void Ok(Pet pet) => this.Pet = pet;
    }
}
