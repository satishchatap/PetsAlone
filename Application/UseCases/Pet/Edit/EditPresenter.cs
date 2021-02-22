namespace Application.UseCases.EditPet
{
   
     using Domain;

    /// <summary>
    /// </summary>
    public sealed class EditPetPresenter : IOutputPort
    {
        public Pet? Pet { get; private set; }
        public bool InvalidOutput { get; private set; }
        public bool NotFoundOutput { get; private set; }
        public void Invalid(Pet pet) { this.InvalidOutput = true; this.Pet = pet; }
        public void NotFound() => this.NotFoundOutput = true;
        public void Ok(Pet pet) => this.Pet = pet;
        public void Get(Pet pet) => this.Pet = pet;
    }
}
