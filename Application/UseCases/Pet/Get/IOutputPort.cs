namespace Application.UseCases.GetPet
{
    using Domain;
    /// <summary>
    ///     Output Port.
    /// </summary>
    public interface IOutputPort
    {
        /// <summary>
        ///     Invalid input.
        /// </summary>
        void Invalid();

        /// <summary>
        ///     Pet closed.
        /// </summary>
        void NotFound();

        /// <summary>
        ///     Pet closed.
        /// </summary>
        void Ok(Pet pet);
    }
}
