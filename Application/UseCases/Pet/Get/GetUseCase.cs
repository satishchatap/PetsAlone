

namespace Application.UseCases.GetPet
{
    using System;
    using System.Threading.Tasks;
    using Domain;
    using Domain.ValueObjects;

    /// <inheritdoc />
    public sealed class GetPetUseCase : IGetPetUseCase
    {
        private readonly IPetRepository _petRepository;
        private IOutputPort _outputPort;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetPetUseCase" /> class.
        /// </summary>
        /// <param name="petRepository">Pet Repository.</param>
        public GetPetUseCase(IPetRepository petRepository)
        {
            this._petRepository = petRepository;
            this._outputPort = new GetPetPresenter();
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public Task Execute(System.Guid petId) =>
            this.GetPetInternal(petId);

        private async Task GetPetInternal(Guid petId)
        {
            IPet pet = await this._petRepository
                .Get(petId)
                .ConfigureAwait(false);

            if (pet is Pet getPet)
            {
                this._outputPort.Ok(getPet);
                return;
            }

            this._outputPort.NotFound();
        }
    }
}
