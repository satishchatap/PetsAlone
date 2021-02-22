namespace Infrastructure.Authentication
{
    using Application.Services;

    /// <inheritdoc />
    public sealed class TestUserService : IUserService
    {
        /// <inheritdoc />
        public string GetCurrentUserId() => SeedData.DefaultCreatedBy;

        /// <inheritdoc />
        public string[] GetCurrentUserPermissions()=> SeedData.DefaultPermission;
    }
}
