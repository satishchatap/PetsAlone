namespace Application.UseCases.EditPet
{
    using Domain;

    /// <summary>
    ///     Open Pet Output Port.
    /// </summary>
    public interface IOutputPort
    {
        /// <summary>
        ///     Pet
        /// </summary>
        void Ok(Pet pet);


        /// <summary>
        ///  Get Pet
        /// </summary>
        /// <param name="pet"></param>

        void Get(Pet pet);

        /// <summary>
        ///     Resource not found.
        /// </summary>
        void NotFound();

        /// <summary>
        ///     Invalid input.
        /// </summary>
        void Invalid(Pet pet);
    }
}
