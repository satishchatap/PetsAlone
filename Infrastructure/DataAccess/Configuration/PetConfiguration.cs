namespace Infrastructure.DataAccess.Configuration
{
    using Domain;
    using Domain.ValueObjects;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    /// <summary>
    ///     Pet Configuration.
    /// </summary>
    public sealed class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        /// <summary>
        ///     Configure Pet.
        /// </summary>
        /// <param name="builder">Builder.</param>
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Pet");
            builder.Property(pet => pet.Name)
                .IsRequired();
            builder.Property(pet => pet.PetType)
                .IsRequired();
            builder.Property(pet => pet.MissingSince)
                .IsRequired();

            //Not Supported in SQL Lite
            //builder.Property(b => b.PetId)
            //    .HasConversion(
            //        v => v.Id,
            //        v => new PetId(v))
            //    .IsRequired();

           

            builder.Property(pet => pet.CreatedBy);
            builder.Property(pet => pet.ModifiedBy);
            builder.Property(b => b.CreatedOn)
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);
            builder.Property(b => b.ModifiedOn)
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);
        }
    }
}
