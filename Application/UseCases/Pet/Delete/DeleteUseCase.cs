namespace Application.UseCases.DeletePet
{
    using Domain;
    using Domain.ValueObjects;
    using Services;
    using System;
    using System.Threading.Tasks;

    /// <inheritdoc />
    public sealed class DeletePetUseCase : IDeletePetUseCase
    {
        private readonly IPetRepository _petRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        private IOutputPort _outputPort;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DeletePetUseCase" /> class.
        /// </summary>
        /// <param name="petRepository">Pet Repository.</param>
        /// <param name="userService">User Service.</param>
        /// <param name="unitOfWork"></param>
        public DeletePetUseCase(
            IPetRepository petRepository,
            IUserService userService,
            IUnitOfWork unitOfWork)
        {
            this._petRepository = petRepository;
            this._userService = userService;
            this._unitOfWork = unitOfWork;
            this._outputPort = new DeletePetPresenter();
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public Task Execute(System.Guid petId)
        {
            string externalUserId = this._userService
                .GetCurrentUserId();

            return this.DeletePetInternal(petId);
        }

        private async Task DeletePetInternal(Guid petId)
        {
            IPet pet = await this._petRepository
                .Get(petId)
                .ConfigureAwait(false);

            if (pet is Pet deletePet)
            {
                await this.DeleteAsync(deletePet)
                    .ConfigureAwait(false);

                this._outputPort.Ok(deletePet);
                return;
            }

            this._outputPort.NotFound();
        }

        private async Task DeleteAsync (Pet deletePet)
        {
            this._petRepository
                .Delete(deletePet.Id);

            await this._unitOfWork
                .Save()
                .ConfigureAwait(false);
        }
    }
}
