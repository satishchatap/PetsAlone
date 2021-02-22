namespace Application.UseCases.GetPet
{
    using System;
    using System.Threading.Tasks;

    /// <inheritdoc />
    public sealed class GetPetValidationUseCase : IGetPetUseCase
    {
        private readonly IGetPetUseCase _useCase;
        private IOutputPort _outputPort;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetPetValidationUseCase" /> class.
        /// </summary>
        public GetPetValidationUseCase(IGetPetUseCase useCase)
        {
            this._useCase = useCase;
            this._outputPort = new GetPetPresenter();
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
            await this._useCase
                .Execute(petId)
                .ConfigureAwait(false);
        }
    }
}
