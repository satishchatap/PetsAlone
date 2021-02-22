

namespace Application.UseCases.EditPet
{
    using Application.Services;
    using System;
    using System.Threading.Tasks;

    /// <inheritdoc />
    public sealed class EditPetValidationUseCase : IEditPetUseCase
    {
        private readonly IEditPetUseCase _useCase;
        private IOutputPort _outputPort;
        private readonly Validation _validation;

        public EditPetValidationUseCase(Validation validation, IEditPetUseCase useCase)
        {
            this._validation = validation;
            this._useCase = useCase;
            this._outputPort = new EditPetPresenter();
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort)
        {
            this._outputPort = outputPort;
            this._useCase.SetOutputPort(outputPort);
        }

        /// <inheritdoc />
        public async Task Execute(Guid petId, string name, int type, DateTime missingSince, string photoPath)
        {
            Validate();
            if (_validation.IsValid)
            {
                await this._useCase
                    .Execute(petId, name, type, missingSince,photoPath)
                    .ConfigureAwait(false);
            }
            else
            {
                this._outputPort.Invalid(new Domain.Pet(petId, name, type, missingSince, photoPath));
            }
        }

        /// <inheritdoc />
        public async Task ExecuteGet(Guid petId)
        {
            await this._useCase
                .ExecuteGet(petId)
                .ConfigureAwait(false);
        }
        private void Validate()
        {
            //Business Validation in case any
            //_validation.Add("name", "Invalid name");
        }
    }
}
