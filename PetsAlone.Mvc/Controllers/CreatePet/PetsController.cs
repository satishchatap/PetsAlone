using Application.Services;
using Application.UseCases.CreatePet;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;
using PetsAlone.Mvc.Models;
using PetsAlone.Mvc.Modules.Common;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PetsAlone.Mvc.Controllers.CreatePet
{
    [FeatureGate(CustomFeature.CreatePet)]
    public class PetsController : BaseController, IOutputPort
    {
        private readonly ICreatePetUseCase _useCase;
        private readonly Validation _validation;
        private ViewResult? _viewResult;
        public PetsController( IMapper mapper, ICreatePetUseCase useCase, Validation validation, IWebHostEnvironment webHostEnvironment)
            : base(mapper,webHostEnvironment)
        {
            _useCase = useCase;
            _mapper = mapper;
            _validation = validation;
        }
        void IOutputPort.Invalid(Pet pet)
        {
            foreach (var e in this._validation.ModelState)
            {
                ModelState.AddModelError(e.Key, e.Value[0]);
            }

            var vm = new CreatePetResponse(_mapper.Map<PetViewModel>(pet)).Pet;
            
            this._viewResult = View("Edit",vm );
        }
        void IOutputPort.NotFound() => this._viewResult = View("Edit", new PetViewModel());

        void IOutputPort.Ok(Pet pet)
        {
            var vm = new CreatePetResponse(_mapper.Map<PetViewModel>(pet)).Pet;
            this._viewResult = View("Details", vm);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View("Edit", new PetViewModel());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(PetViewModel petViewModel)
        {
            if (ModelState.IsValid)
            {
                _useCase.SetOutputPort(this);
                petViewModel.PhotoPath = ProcessUploadedFile(petViewModel.Photo);
                await _useCase.Execute(petViewModel.Name, petViewModel.PetType, petViewModel.MissingSince, petViewModel.PhotoPath)
                    .ConfigureAwait(false);
                return this._viewResult!;
            }
            return View("Edit", petViewModel);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
        
    }
}