using Domain;

namespace Application.UseCases.DeletePet
{
    /// <summary>
    /// Delete Pet Presenter
    /// </summary>
    public sealed class DeletePetPresenter : IOutputPort
    {
        public Pet? Pet { get; private set; }
        public bool NotFoundOutput { get; private set; }
        public bool InvalidOutput { get; private set; }
        public void Invalid() => this.InvalidOutput = true;
        public void NotFound() => this.NotFoundOutput = true;
        public void Ok(Pet pet) => this.Pet = pet;
    }
}
