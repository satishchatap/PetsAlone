using Application.UseCases.GetAllPets;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;
using PetsAlone.Mvc.Models;
using PetsAlone.Mvc.Modules.Common;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PetsAlone.Mvc.Controllers.GetAllPets
{
    [FeatureGate(CustomFeature.GetAllPets)]
    public class PetsController : BaseController, IOutputPort
    {
        private readonly IGetAllPetsUseCase _useCase;

        private IList<PetViewModel> _responseModel= new List<PetViewModel>();
        public PetsController( IMapper mapper, IGetAllPetsUseCase useCase, IWebHostEnvironment webHostEnvironment)
            : base(mapper, webHostEnvironment)
        {
            _useCase = useCase;
            _mapper = mapper;
        }

        void IOutputPort.Ok(IList<Pet> pets) => this._responseModel = (new GetAllPetsResponse(_mapper.Map<IList<PetViewModel>>(pets))).Pets;
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            this._useCase.SetOutputPort(this);

            await this._useCase.Execute(0)
                .ConfigureAwait(false);

            return View(_responseModel);
           
        }
        [HttpPost]
        public async Task<IActionResult> Index([FromForm] int petType = 0)
        {
            this._useCase.SetOutputPort(this);

            await this._useCase.Execute(petType)
                .ConfigureAwait(false);

            return View(_responseModel);

        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
        
    }
}