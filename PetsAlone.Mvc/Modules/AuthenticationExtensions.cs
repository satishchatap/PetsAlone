

namespace PetsAlone.Mvc.Modules
{
    using Application.Services;
    using Domain;
    using Infrastructure.Authentication;
    using Infrastructure.DataAccess;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.FeatureManagement;
    using PetsAlone.Mvc.Modules.Common;

    /// <summary>
    ///     Authentication Extensions.
    /// </summary>
    public static class AuthenticationExtensions
    {
        /// <summary>
        ///     Add Authentication Extensions.
        /// </summary>
        public static IServiceCollection AddAuthentication(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            IFeatureManager featureManager = services
                .BuildServiceProvider()
                .GetRequiredService<IFeatureManager>();

            bool isEnabled = featureManager
                .IsEnabledAsync(nameof(CustomFeature.Authentication))
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();

            if (isEnabled)
            {
                services.AddScoped<IUserService, UserService>();

                services.AddDefaultIdentity<ApplicationUser>()
                    .AddEntityFrameworkStores<DataContext>();
            }
            else
            {
                services.AddScoped<IUserService, UserService>();

                services.AddDefaultIdentity<ApplicationUser>()
                  .AddEntityFrameworkStores<DataContextFake>();
            }

            return services;
        }
    }
}
