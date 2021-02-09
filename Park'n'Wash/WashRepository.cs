using Park_n_Wash.Wash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash
{
    class WashRepository : IRepository<IWash>
    {
        private List<IWash> _washes;

        public WashRepository()
        {
            _washes = new List<IWash>();
        }

        /// <summary>
        /// Add wash to repository.
        /// </summary>
        /// <param name="wash"><see cref="IWash"/> to insert.</param>
        public bool Insert(IWash wash)
        {
            if (wash.IsValid)
            {
                _washes.Add(wash);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Get list of washes.
        /// </summary>
        /// <returns><see cref="IEnumerable{T}"/></returns>
        public IEnumerable<IWash> GetAll()
        {
            return _washes;
        }

        /// <summary>
        /// Get wash by id.
        /// </summary>
        /// <param name="id">Id of <see cref="IWash"/>.</param>
        /// <returns><see cref="IWash"/></returns>
        public IWash GetById(int id)
        {
            return _washes.Where(x => x.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Update existing wash in repository. If it doesn't exist; insert it.
        /// </summary>
        /// <param name="wash"><see cref="IWash"/> to update (or insert).</param>
        public bool Update(IWash wash)
        {
            IWash washToUpdate = _washes.Where(x => x.Id == wash.Id).FirstOrDefault();
            if (washToUpdate != null && wash.IsValid)
            {
                washToUpdate = wash;
                return true;
            }
            else
            {
                return Insert(wash);
            }
        }

        /// <summary>
        /// Delete wash with given id.
        /// </summary>
        /// <param name="id">Id of <see cref="IWash"/>.</param>
        public void Delete(int id)
        {
            _washes.RemoveAll(x => x.Id == id);
        }
    }
}
