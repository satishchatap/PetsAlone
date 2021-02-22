namespace Application.UseCases.GetPets
{
    using System.Threading.Tasks;

    /// <summary>
    ///         Case Domain-Driven Design Pattern
    /// </summary>
    public interface IGetPetsUseCase
    {
        /// <summary>
        ///     Executes the use case.
        /// </summary>
        /// <returns>Task.</returns>
        Task Execute();

        /// <summary>
        ///     Sets the Output Port.
        /// </summary>
        /// <param name="outputPort">Output Port</param>
        void SetOutputPort(IOutputPort outputPort);
    }
}
