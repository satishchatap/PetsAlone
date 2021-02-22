namespace PetsAlone.Mvc.Modules
{
    using Application.Services;
    using Common;
    using Domain;
    using Infrastructure;
    using Infrastructure.DataAccess;
    using Infrastructure.DataAccess.Repositories;
    using Microsoft.Data.Sqlite;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.FeatureManagement;
    using System.Data.Common;

    /// <summary>
    ///     Persistence Extensions.
    /// </summary>
#pragma warning disable S101 // Types should be named in PascalCase
    public static class SQLServerExtensions
#pragma warning restore S101 // Types should be named in PascalCase
    {
        /// <summary>
        ///     Add Persistence dependencies varying on configuration.
        /// </summary>
        public static IServiceCollection AddSQLServer(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            IFeatureManager featureManager = services
                .BuildServiceProvider()
                .GetRequiredService<IFeatureManager>();

            bool isEnabled = featureManager
                .IsEnabledAsync(nameof(CustomFeature.SQLServer))
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();

            if (isEnabled)
            {
                services.AddDbContext<DataContext>(
                    options => options.UseSqlServer(
                        configuration.GetValue<string>("PersistenceModule:DefaultConnection")));
                services.AddScoped<IUnitOfWork, UnitOfWork>();

                services.AddScoped<IPetRepository, PetRepository>();
            }
            else
            {
                var builder = new SqliteConnectionStringBuilder()
                {
                    DataSource = "Filename=PetsAlone.db",
                    Mode = SqliteOpenMode.Memory,
                    Cache = SqliteCacheMode.Shared
                };

                services.AddDbContext<DataContextFake>(opts =>
                    {
                         var connection = new SqliteConnection(builder.ConnectionString);
                        connection.Open();
                        connection.EnableExtensions(true);
                        opts.UseSqlite(connection);
                    }
                );
                services.AddScoped<IUnitOfWork, UnitOfWorkFake>();
                services.AddScoped<IPetRepository, PetRepositoryFake>();
            }

            services.AddScoped<IPetFactory, EntityFactory>();

            return services;
        }
    }
}