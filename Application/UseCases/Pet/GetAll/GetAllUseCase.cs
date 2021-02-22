namespace Application.UseCases.GetAllPets
{
    using AutoMapper;
    using Domain;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;

    /// <inheritdoc />
    public sealed class GetAllPetsUseCase : IGetAllPetsUseCase
    {
        private readonly IPetRepository _petRepository;
        private IOutputPort _outputPort;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetAllPetsUseCase" /> class.
        /// </summary>
        /// <param name="petRepository">Pet Repository.</param>
        public GetAllPetsUseCase(
            IPetRepository petRepository, IMapper mapper)
        {
            this._petRepository = petRepository;
            this._outputPort = new GetAllPetPresenter();
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public Task Execute(int petId=0)
        {
            return this.GetAllPets(petId);
        }
        private async Task GetAllPets(int petId = 0)
        {
            IList<Pet> pets = await this._petRepository
                .GetAll(petId)
                .ConfigureAwait(false);

            this._outputPort.Ok(pets.OrderByDescending(a=>a.MissingSince).ToList());
        }

    }
}
