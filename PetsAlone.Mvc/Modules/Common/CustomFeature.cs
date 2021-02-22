namespace PetsAlone.Mvc.Modules.Common
{
    public enum CustomFeature
    {   
        /// <summary>
        /// Pet
        /// </summary>
        CreatePet,
        /// <summary>
        ///     Get Pet.
        /// </summary>
        GetPet,

        /// <summary>
        ///     Get Pets.
        /// </summary>
        GetPets,

        /// <summary>
        ///     Filter errors out.
        /// </summary>
        ErrorFilter,

        /// <summary>
        ///     Use SQL Server Persistence.
        /// </summary>
        SQLServer,        

        /// <summary>
        ///     Use authentication.
        /// </summary>
        Authentication,

        /// <summary>
        ///     Edit Pet
        /// </summary>
        EditPet,

        /// <summary>
        ///     Delete Pet
        /// </summary>
        DeletePet,

        /// <summary>
        /// Get All Pets
        /// </summary>
        GetAllPets,

        /// <summary>
        ///     Use authorization
        /// </summary>
        Authorization
    }
}
