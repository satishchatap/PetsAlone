using System;
using System.Threading.Tasks;

namespace Application.UseCases.DeletePet
{
    /// <summary>
    /// Delete Pet use Case
    /// </summary>
    public interface IDeletePetUseCase
    {
        /// <summary>
        ///     Executes the use case.
        /// </summary>
        /// <param name="petId">Pet Id.</param>
        /// <returns>Task.</returns>
        Task Execute(Guid petId);

        /// <summary>
        ///     Sets the Output Port.
        /// </summary>
        /// <param name="outputPort">Output Port</param>
        void SetOutputPort(IOutputPort outputPort);
    }
}
