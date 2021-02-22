using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain
{

    public interface IRepository<T>
    {
        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> Get(Guid id);

        /// <summary>
        /// Get All 
        /// </summary>
        /// <returns></returns>
        Task<IList<T>> GetAll();

        /// <summary>
        ///     Adds 
        /// </summary>
        /// <param name="entity"> object.</param>
        /// <returns>Task.</returns>
        Task Add(T entity);

        /// <summary>
        ///     Update.
        /// </summary>
        /// <param name="entity"> object.</param>
        /// <returns>Task.</returns>
        Task Update(T entity);

        /// <summary>
        ///     Deletes .
        /// </summary>
        /// <param name="id"> Id.</param>
        /// <returns>Task.</returns>
        void Delete(Guid petId);



    }
}
