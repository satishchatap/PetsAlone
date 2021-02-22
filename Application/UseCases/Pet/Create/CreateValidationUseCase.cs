

namespace Application.UseCases.CreatePet
{
    using Application.Services;
    using System;
    using System.Threading.Tasks;

    /// <inheritdoc />
    public sealed class CreatePetValidationUseCase : ICreatePetUseCase
    {
        private readonly ICreatePetUseCase _useCase;
        private IOutputPort _outputPort;
        private readonly Validation _validation;

        public CreatePetValidationUseCase(Validation validation, ICreatePetUseCase useCase)
        {
            this._validation = validation;
            this._useCase = useCase;
            this._outputPort = new CreatePetPresenter();
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort)
        {
            this._outputPort = outputPort;
            this._useCase.SetOutputPort(outputPort);
        }

        /// <inheritdoc />
        public async Task Execute(string name, int type, DateTime missingSince, string photoPath)
        {
            Validate();
            if (_validation.IsValid)
            {
                await this._useCase
                    .Execute(name, type, missingSince,photoPath)
                    .ConfigureAwait(false);
            }
            else
            {
                this._outputPort.Invalid(new Domain.Pet(name,type,missingSince, photoPath));
            }
        }
        private void Validate()
        {
            //Business Validation in case any
            //_validation.Add("name", "Invalid name");
        }
    }
}
