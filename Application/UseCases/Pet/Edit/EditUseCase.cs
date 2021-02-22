namespace Application.UseCases.EditPet
{
    using Domain;
    using Services;
    using System;
    using System.Threading.Tasks;

    /// <inheritdoc />
    public sealed class EditPetUseCase : IEditPetUseCase
    {
       
        private readonly IPetRepository _petRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private IOutputPort _outputPort;

        public EditPetUseCase(
            IPetRepository petRepository,
            IUnitOfWork unitOfWork,
            IUserService userService)
        {
            this._petRepository = petRepository;
            this._unitOfWork = unitOfWork;
            this._userService = userService;
            this._outputPort = new EditPetPresenter();
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public Task Execute(Guid petId, string name, int type, DateTime missingSince, string photoPath) =>
            this.EditPet(petId,name, type, missingSince, photoPath);
        /// <inheritdoc />
        public Task ExecuteGet(Guid petId) =>
            this.EditPetGet(petId);

        private async Task EditPetGet(Guid petId)
        {
            string externalUserId = this._userService
                .GetCurrentUserId();
            var domainPetId = petId;
            var petExisting = await this._petRepository.Get(domainPetId)
                .ConfigureAwait(false);


            this._outputPort?.Get((Pet)petExisting);
        }

        private async Task EditPet(Guid petId,string name, int type, DateTime missingSince, string? photoPath)
        {
            string externalUserId = this._userService
                .GetCurrentUserId();
            var domainPetId = petId;
            var petExisting =await this._petRepository.Get(domainPetId)
                .ConfigureAwait(false);

            petExisting.Name = name;
            petExisting.PetType = type;
            petExisting.MissingSince = missingSince;
            petExisting.PhotoPath = photoPath?? petExisting.PhotoPath;

            //pet.Audit(externalUserId, AuditType.Modify);

            await this.Pet((Pet)petExisting)
                .ConfigureAwait(false);

            this._outputPort?.Ok((Pet)petExisting);
        }

#pragma warning disable IDE0060 // Remove unused parameter
        private async Task Pet(Pet pet)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            //await this._petRepository
            //    .Update(pet)
            //    .ConfigureAwait(false);

            await this._unitOfWork
                .Save()
                .ConfigureAwait(false);
        }
    }
}
