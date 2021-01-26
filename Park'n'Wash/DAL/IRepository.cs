using System;
using System.Collections.Generic;
using System.Text;

namespace Park_n_Wash.DAL
{
    public interface IRepository<T>
    {
        /// <summary>
        /// Get enumerable of <see cref="T"/>.
        /// </summary>
        /// <returns><see cref="IEnumerable{T}"/></returns>
        IEnumerable<T> Get();

        /// <summary>
        /// Get <see cref="T"/> with given id.
        /// </summary>
        /// <param name="id">Id of <see cref="T"/>.</param>
        /// <returns><see cref="T"/></returns>
        T GetById(int id);

        /// <summary>
        /// Insert <see cref="T"/> into repository.
        /// </summary>
        /// <param name="t">Object to insert.</param>
        void Insert(T t);

        /// <summary>
        /// Update <see cref="T"/> in repository.
        /// </summary>
        /// <param name="t">Object to update.</param>
        void Update(T t);

        /// <summary>
        /// Delete <see cref="T"/> with given id.
        /// </summary>
        /// <param name="id">Id of <see cref="T"/>.</param>
        void Delete(int id);

        /// <summary>
        /// Check whether <see cref="T"/> meets reqirements to be valid.
        /// </summary>
        /// <param name="t">Object to validate.</param>
        /// <returns>True if valid; otherwise false.</returns>
        bool Validate(T t);

        /// <summary>
        /// Save changes made in repository.
        /// </summary>
        void Save();
    }
}
