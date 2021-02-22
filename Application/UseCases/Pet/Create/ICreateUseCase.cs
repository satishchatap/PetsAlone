using System;
using System.Threading.Tasks;

namespace Application.UseCases.CreatePet
{
    public interface ICreatePetUseCase
    {
        /// <summary>
        ///     Executes the Use Case
        /// </summary>
        Task Execute(string name, int type, DateTime missingSince,string photoPath);

        /// <summary>
        ///     Sets the Output Port.
        /// </summary>
        /// <param name="outputPort">Output Port</param>
        void SetOutputPort(IOutputPort outputPort);
    }
}
