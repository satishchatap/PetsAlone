using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// If you want to extend bas repository
    /// </summary>
    public interface IPetRepository 
    {
        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IPet> Get(Guid id);

        /// <summary>
        /// Get All 
        /// </summary>
        /// <returns></returns>
        Task<IList<Pet>> GetAll(int petType);

        /// <summary>
        ///     Adds 
        /// </summary>
        /// <param name="entity"> object.</param>
        /// <returns>Task.</returns>
        Task Add(Pet entity);

        /// <summary>
        ///     Update.
        /// </summary>
        /// <param name="entity"> object.</param>
        /// <returns>Task.</returns>
        Task Update(Pet entity);

        /// <summary>
        ///     Deletes .
        /// </summary>
        /// <param name="id"> Id.</param>
        /// <returns>Task.</returns>
        void Delete(Guid petId);
        Task<IList<Pet>> GetPets(string externalUserId);
    }
}
