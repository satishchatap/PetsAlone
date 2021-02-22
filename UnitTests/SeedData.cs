

namespace UnitTests
{
    using System;
    using Domain;
    using Domain.ValueObjects;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// </summary>
    public static class SeedData
    {
        public static readonly string DefaultUserId = "197D0438-E04B-453D-B5DE-ECA05960C6AE";

        public static readonly Guid DefaultPetId =
            new Guid("4C510CFE-5D61-4A46-A3D9-C4313426655F");

        public static readonly string DefaultAuthor = "schatap";

        public static readonly Guid SecondPetId =
            new Guid("E82D2EA6-E9D3-444D-A22F-9D65F2F2C65E");

        public static readonly string SecondExternalUserId = "C70E69BF-EDC7-48E3-BF33-B424F7464C5F";

        public static void Seed(ModelBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Entity<Pet>()
                .HasData(
                    new
                    {
                        Id = DefaultPetId,
                        MissingSince = DateTime.UtcNow,
                        PetType = 1,
                        PhotoPath=""
                    });
        }
    }
}
