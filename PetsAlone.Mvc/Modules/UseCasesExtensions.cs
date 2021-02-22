namespace PetsAlone.Mvc.Modules
{
    using Application.Services;
    using Application.UseCases.CreatePet;
    using Application.UseCases.DeletePet;
    using Application.UseCases.EditPet;
    using Application.UseCases.GetAllPets;
    using Application.UseCases.GetPet;
    using Application.UseCases.GetPets;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    ///     Adds Use Cases classes.
    /// </summary>
    public static class UseCasesExtensions
    {
        /// <summary>
        ///     Adds Use Cases to the ServiceCollection.
        /// </summary>
        /// <param name="services">Service Collection.</param>
        /// <returns>The modified instance.</returns>
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<Validation, Validation>();

            services.AddScoped<ICreatePetUseCase, CreatePetUseCase>();
            services.Decorate<ICreatePetUseCase, CreatePetValidationUseCase>();

            services.AddScoped<IGetPetUseCase, GetPetUseCase>();
            services.Decorate<IGetPetUseCase, GetPetValidationUseCase>();

            services.AddScoped<IEditPetUseCase, EditPetUseCase>();
            services.Decorate<IEditPetUseCase, EditPetValidationUseCase>();

            services.AddScoped<IDeletePetUseCase, DeletePetUseCase>();
            services.Decorate<IDeletePetUseCase, DeletePetValidationUseCase>();

            services.AddScoped<IGetPetsUseCase, GetPetsUseCase>();

            services.AddScoped<IGetAllPetsUseCase, GetAllPetsUseCase>();

            return services;
        }
    }
}
