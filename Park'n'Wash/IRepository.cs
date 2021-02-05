using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash
{
    public interface IRepository<T>
    {
        /// <summary>
        /// Insert <see cref="T"/> into repository.
        /// </summary>
        /// <param name="t">Object to insert.</param>
        bool Insert(T t);

        /// <summary>
        /// Get enumerable of <see cref="T"/>.
        /// </summary>
        /// <returns><see cref="IEnumerable{T}"/></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Get <see cref="T"/> with given id.
        /// </summary>
        /// <param name="id">Id of <see cref="T"/>.</param>
        /// <returns><see cref="T"/></returns>
        T GetById(int id);

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
    }
}
