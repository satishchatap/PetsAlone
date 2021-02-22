using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace PetsAlone.Mvc.Controllers
{
    public abstract class BaseController : Controller
    {
        internal  IMapper _mapper;
        internal IWebHostEnvironment _webHostEnvironment;
        public BaseController(IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _mapper = mapper;
           _webHostEnvironment = webHostEnvironment;
        }
        #region Private
        internal VM GetViewModel <VM,T>(T p) => _mapper.Map<VM>(p);
        internal T GetEntity<VM, T>(VM p) => _mapper.Map<T>(p);
        #endregion

        public string ProcessUploadedFile(IFormFile photo)
        {
            string uniqueFileName = string.Empty;

            if (photo != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}
