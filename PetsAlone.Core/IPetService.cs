using PetsAlone.Core.Domain;
using System.Collections.Generic;

namespace PetsAlone.Core
{
    public interface IPetsService 
    {
        List<Pet> GetAll();
        Pet Get(int id);
        Pet Create(Pet pet);
        bool Update(Pet pet);
        bool Delete(int id);
    }
}
