using System;
using System.Threading.Tasks;

namespace Application.UseCases.GetPet
{
    public interface IGetPetUseCase
    {
        /// <summary>
        ///     Executes the Use Case
        /// </summary>
        /// <param name="petId">Account Id.</param>
        Task Execute(Guid petId);

        /// <summary>
        ///     Executes the Use Case.
        /// </summary>
        /// <param name="outputPort"></param>
        void SetOutputPort(IOutputPort outputPort);
    }
}
