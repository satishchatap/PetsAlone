using Application.UseCases.GetPet;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;
using PetsAlone.Mvc.Models;
using PetsAlone.Mvc.Modules.Common;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PetsAlone.Mvc.Controllers.GetPet
{
    [FeatureGate(CustomFeature.GetPets)]
    public class PetsController : BaseController, IOutputPort
    {
        private readonly IGetPetUseCase _useCase;
        private ViewResult _viewResult;
        public PetsController( IMapper mapper, IGetPetUseCase useCase, IWebHostEnvironment webHostEnvironment)
            : base(mapper, webHostEnvironment)
        {
            _useCase = useCase;
            _mapper = mapper;
        }

        void IOutputPort.Ok(Pet pet) => this._viewResult = View("Details", 
            (new GetPetResponse(_mapper.Map<PetViewModel>( pet))).Pet);
        void IOutputPort.NotFound() => this._viewResult = View("Information", new InfoViewModel("Pet not found.", InfoType.Error));
        void IOutputPort.Invalid() => this._viewResult = View("Information", new InfoViewModel("Pet not found.", InfoType.Error));
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            this._useCase.SetOutputPort(this);

            await this._useCase.Execute(id)
                .ConfigureAwait(false);

            return _viewResult;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
        
    }
}