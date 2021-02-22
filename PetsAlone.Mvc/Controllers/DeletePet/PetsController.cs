using Application.Services;
using Application.UseCases.DeletePet;
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

namespace PetsAlone.Mvc.Controllers.DeletePet
{
    [FeatureGate(CustomFeature.DeletePet)]
    public class PetsController : BaseController, IOutputPort
    {
        private readonly IDeletePetUseCase _useCase;
        private ViewResult? _viewResult;
        public PetsController( IMapper mapper, IDeletePetUseCase useCase, IWebHostEnvironment webHostEnvironment)
            : base(mapper, webHostEnvironment)
        {
            _useCase = useCase;
            _mapper = mapper;
        }
        void IOutputPort.NotFound() => this._viewResult = View("Information", new InfoViewModel("Pet not found.", InfoType.Error));
        void IOutputPort.Invalid() => this._viewResult = View("Information", new InfoViewModel("Pet not found.", InfoType.Error));


        void IOutputPort.Ok(Pet pet) =>
            this._viewResult = this._viewResult = View("Information", new InfoViewModel("Pet delete succesfully.", InfoType.Error));


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id )
        {
            _useCase.SetOutputPort(this);

            await _useCase.Execute(id)
                .ConfigureAwait(false);

            return this._viewResult!;
        }

       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
        
    }
}