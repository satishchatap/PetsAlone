namespace Application.UseCases.CreatePet
{
    using Domain;

    /// <summary>
    ///     Open Pet Output Port.
    /// </summary>
    public interface IOutputPort
    {
        /// <summary>
        ///     Pet open.
        /// </summary>
        void Ok(Pet pet);

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
