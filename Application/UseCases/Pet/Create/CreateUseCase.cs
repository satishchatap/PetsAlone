namespace Application.UseCases.CreatePet
{
    using Domain;
    using Services;
    using System;
    using System.Threading.Tasks;

    /// <inheritdoc />
    public sealed class CreatePetUseCase : ICreatePetUseCase
    {
        private readonly IPetRepository _petRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly IPetFactory _petFactory;
        private IOutputPort _outputPort;

        public CreatePetUseCase(
            IPetRepository petRepository,
            IUnitOfWork unitOfWork,
            IUserService userService,
            IPetFactory petFactory)
        {
            this._petRepository = petRepository;
            this._unitOfWork = unitOfWork;
            this._userService = userService;
            this._petFactory = petFactory;
            this._outputPort = new CreatePetPresenter();
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public Task Execute(string name, int type, DateTime missingSince, string photoPath) =>
            this.CreatePet(name, type, missingSince, photoPath);

        private async Task CreatePet(string name, int type, DateTime missingSince,string photoPath)
        {
            string externalUserId = this._userService
                .GetCurrentUserId();

            Pet pet = this._petFactory
                .NewPet( name, type, missingSince, photoPath);
            //pet.Audit(externalUserId, AuditType.Add);
            await this.Pet(pet)
                .ConfigureAwait(false);

            this._outputPort?.Ok(pet);
        }

        private async Task Pet(Pet pet)
        {
            await this._petRepository
                .Add(pet)
                .ConfigureAwait(false);

            await this._unitOfWork
                .Save()
                .ConfigureAwait(false);
        }
    }
}
