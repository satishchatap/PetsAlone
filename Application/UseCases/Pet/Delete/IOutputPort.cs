using Domain;

namespace Application.UseCases.DeletePet
{
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
        ///     Pet deleted successfully.
        /// </summary>
        void Ok(Pet account);

        /// <summary>
        ///     Pet not found.
        /// </summary>
        void NotFound();
    }
}
