
namespace Infrastructure.DataAccess
{
    using System;
    using System.IO;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    ///     ContextFactory.
    /// </summary>
    public sealed class ContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        /// <summary>
        ///     Instantiate a DataContext.
        /// </summary>
        /// <param name="args">Command line args.</param>
        /// <returns>Data Context.</returns>
        public DataContext CreateDbContext(string[] args)
        {
            string connectionString = ReadDefaultConnectionStringFromAppSettings();

            DbContextOptionsBuilder<DataContext> builder = new DbContextOptionsBuilder<DataContext>();
            Console.WriteLine(connectionString);
            builder.UseSqlServer(connectionString);
            builder.EnableSensitiveDataLogging();
            return new DataContext(builder.Options);
        }

        private static string ReadDefaultConnectionStringFromAppSettings()
        {
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
            string? envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json", false)
                .AddJsonFile($"appsettings.{envName}.json", false)
                .AddEnvironmentVariables()
                .Build();

            string connectionString = configuration.GetValue<string>("PersistenceModule:DefaultConnection");
            return connectionString;
        }
    }
}

