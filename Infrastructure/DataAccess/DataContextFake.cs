namespace Infrastructure.DataAccess
{
    using Domain;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System;

    public sealed class DataContextFake : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Pet> Pets { get; set; }
        private PasswordHasher<ApplicationUser> PasswordHasher { get; set; }

        public DataContextFake(
            DbContextOptions<DataContextFake> options) : base(options)
        {
            PasswordHasher = new PasswordHasher<ApplicationUser>();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("ApplicationUsers");
            modelBuilder.Entity<Pet>().ToTable("Pet");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContextFake).Assembly);



            modelBuilder.Entity<Pet>().HasData(new Pet
            (
                id: new Guid("4C510CFE-5D61-4A46-A3D9-C4313426655F"),
                name: "Max",
                petType: 2,
                missingSince: DateTime.Now.Subtract(TimeSpan.FromDays(6))
            ));

            modelBuilder.Entity<Pet>().HasData(new Pet(
                id: new Guid("E82D2EA6-E9D3-444D-A22F-9D65F2F2C65E"),
                name: "Fluffy",
                petType: 1,
                missingSince: DateTime.Now.Subtract(TimeSpan.FromDays(10))
            ));

            modelBuilder.Entity<Pet>().HasData(new Pet
            (
                id: new Guid("C70E69BF-EDC7-48E3-BF33-B424F7464C5F"),
                name: "Snowball",
                petType: 4,
                missingSince: DateTime.Now.Subtract(TimeSpan.FromDays(2))
            ));

            SeedApplicationUsers(modelBuilder);
        }

        private void SeedApplicationUsers(ModelBuilder modelBuilder)
        {
            var username = "elmyraduff";
            var email = "elmyraduff@petsalone.com";
            var password = "MontanaMax!!";

            var user = new ApplicationUser
            {
                UserName = username,
                NormalizedUserName = username.ToUpper(),
                Email = email,
                NormalizedEmail = email.ToUpper(),
                EmailConfirmed = true,
                LockoutEnabled = false,
            };
            user.PasswordHash = PasswordHasher.HashPassword(user, password);

            modelBuilder.Entity<ApplicationUser>().HasData(user);
        }
    }
}