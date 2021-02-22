namespace Application.UseCases.DeletePet
{
    using System;
    using System.Threading.Tasks;
    using Services;

    /// <inheritdoc />
    public sealed class DeletePetValidationUseCase : IDeletePetUseCase
    {
        private readonly IDeletePetUseCase _useCase;
        private readonly Validation _validation;
        private IOutputPort _outputPort;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DeletePetValidationUseCase" /> class.
        /// </summary>
        public DeletePetValidationUseCase(IDeletePetUseCase useCase, Validation validation)
        {
            this._useCase = useCase;
            this._validation = validation;
            this._outputPort = new DeletePetPresenter();
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort)
        {
            this._outputPort = outputPort;
            this._useCase.SetOutputPort(outputPort);
        }

        /// <inheritdoc />
        public async Task Execute(Guid petId)
        {
            if (petId == Guid.Empty)
            {
                this._validation
                    .Add(nameof(petId), "AccountId is required.");
            }

            if (!this._validation
                .IsValid)
            {
                this._outputPort
                    .Invalid();
                return;
            }

            await this._useCase
                .Execute(petId)
                .ConfigureAwait(false);
        }
    }
}
