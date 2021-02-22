namespace Application.UseCases.GetPets
{
    using Domain;
    using System.Collections.Generic;

    public sealed class GetPetPresenter : IOutputPort
    {
        public IList<Pet> Pets { get; private set; }
        public void Ok(IList<Pet> pets) => this.Pets = pets;
    }
}
