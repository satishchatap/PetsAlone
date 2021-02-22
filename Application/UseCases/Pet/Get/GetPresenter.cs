namespace Application.UseCases.GetPet
{
    using Domain;
    public sealed class GetPetPresenter : IOutputPort
    {
        public Pet? Pet { get; private set; }
        public bool? IsNotFound { get; private set; }
        public bool? InvalidOutput { get; private set; }
        public void Invalid() => this.InvalidOutput = true;
        public void NotFound() => this.IsNotFound = true;
        public void Ok(Pet pet)
        {
            this.Pet = pet;
        }
    }
}
