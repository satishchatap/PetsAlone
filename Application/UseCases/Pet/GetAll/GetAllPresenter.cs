namespace Application.UseCases.GetAllPets
{
    using Domain;
    using System.Collections.Generic;

    public sealed class GetAllPetPresenter : IOutputPort
    {
        public GetAllPetPresenter()
        {
        }
        public IList<Pet>? Pets { get; private set; }
        public void Ok(IList<Pet> pets)  
        {
            this.Pets =  pets;
        }
    }
}
