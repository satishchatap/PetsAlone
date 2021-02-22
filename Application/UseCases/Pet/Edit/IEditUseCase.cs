using System;
using System.Threading.Tasks;

namespace Application.UseCases.EditPet
{
    public interface IEditPetUseCase
    {
        /// <summary>
        ///     Executes the Use Case
        /// </summary>
        Task Execute(Guid petId,string name, int type, DateTime missingSince, string photoPath);

        /// <summary>
        ///     Executes the Use Case
        /// </summary>
        Task ExecuteGet(Guid petId);

        /// <summary>
        ///     Sets the Output Port.
        /// </summary>
        /// <param name="outputPort">Output Port</param>
        void SetOutputPort(IOutputPort outputPort);
    }
}
