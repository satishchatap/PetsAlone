namespace Application.UseCases.GetAllPets
{
    using System.Threading.Tasks;

    /// <summary>
    ///         Case Domain-Driven Design Pattern
    /// </summary>
    public interface IGetAllPetsUseCase
    {
        /// <summary>
        ///     Executes the use case.
        /// </summary>
        /// <returns>Task.</returns>
        Task Execute(int petId);

        /// <summary>
        ///     Sets the Output Port.
        /// </summary>
        /// <param name="outputPort">Output Port</param>
        void SetOutputPort(IOutputPort outputPort);
    }
}
