namespace PetsAlone.Mvc
{
    using AutoMapper;
    using Domain;
    using PetsAlone.Mvc.Models;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Pet, PetViewModel>()
                    .ReverseMap(); 
        }
    }
}
