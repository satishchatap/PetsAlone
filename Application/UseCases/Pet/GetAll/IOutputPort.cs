namespace Application.UseCases.GetAllPets
{
    using System.Collections.Generic;
    using Domain;

    /// <summary>
    ///     Output Port.
    /// </summary>
    public interface IOutputPort
    {
        /// <summary>
        ///     Listed pets.
        /// </summary>
        void Ok(IList<Pet> pets);
    }
}
