using Application.Services;
using Application.UseCases.EditPet;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;
using PetsAlone.Mvc.Models;
using PetsAlone.Mvc.Modules.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PetsAlone.Mvc.Controllers.EditPet
{
    [FeatureGate(CustomFeature.EditPet)]
    public class PetsController : BaseController, IOutputPort
    {
        private readonly IEditPetUseCase _useCase;
        private readonly Validation _validation;
        private ViewResult? _viewResult;
        public PetsController( IMapper mapper, IEditPetUseCase useCase, Validation validation, IWebHostEnvironment webHostEnvironment)
            : base(mapper, webHostEnvironment)
        {
            _useCase = useCase;
            _mapper = mapper;
            _validation = validation;
        }
        void IOutputPort.Invalid(Pet pet)
        {
            foreach (var e in this._validation.ModelState)
            { 
                ModelState.AddModelError(e.Key,e.Value[0]); 
            }
            
            var vm = new EditPetResponse(_mapper.Map<PetViewModel>(pet)).Pet;
            
            this._viewResult = View("Edit",vm );
        }
        void IOutputPort.NotFound() => this._viewResult = View("Edit", new PetViewModel());

        void IOutputPort.Ok(Pet pet) =>
            this._viewResult =View("Details", new EditPetResponse(_mapper.Map<PetViewModel>(pet)).Pet);
        void IOutputPort.Get(Pet pet) =>
            this._viewResult = View("Edit", new EditPetResponse(_mapper.Map<PetViewModel>(pet)).Pet);

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(Guid id )
        {
            _useCase.SetOutputPort(this);

            await _useCase.ExecuteGet(id)
                .ConfigureAwait(false);

            return this._viewResult!;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(Guid id, PetViewModel petViewModel)
        {
            if (ModelState.IsValid)
            {
                _useCase.SetOutputPort(this);
                if(petViewModel.Photo!=null)
                petViewModel.PhotoPath = ProcessUploadedFile(petViewModel.Photo);
                await _useCase.Execute(id, petViewModel.Name, petViewModel.PetType, petViewModel.MissingSince, petViewModel.PhotoPath)
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