namespace Application.UseCases.GetPets
{
    using Domain;
    using Services;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <inheritdoc />
    public sealed class GetPetsUseCase : IGetPetsUseCase
    {
        private readonly IPetRepository _petRepository;
        private readonly IUserService _userService;
        private IOutputPort _outputPort;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetPetsUseCase" /> class.
        /// </summary>
        /// <param name="userService">User Service.</param>
        /// <param name="petRepository">Pet Repository.</param>
        public GetPetsUseCase(
            IUserService userService,
            IPetRepository petRepository)
        {
            this._userService = userService;
            this._petRepository = petRepository;
            this._outputPort = new GetPetPresenter();
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public Task Execute()
        {
            string externalUserId = this._userService
                .GetCurrentUserId();

            return this.GetPets(externalUserId);
        }

        private async Task GetPets(string externalUserId)
        {
            IList<Pet>? pets = await this._petRepository
                .GetPets(externalUserId)
                .ConfigureAwait(false);

            this._outputPort.Ok(pets);
        }
    }
}
