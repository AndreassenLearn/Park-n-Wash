using Park_n_Wash.Wash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash
{
    class CarWashRepository : IRepository<CarWash>
    {
        private List<CarWash> _carWashes;

        public CarWashRepository()
        {
            _carWashes = new List<CarWash>();
        }

        /// <summary>
        /// Add car wash to repository.
        /// </summary>
        /// <param name="carWash"><see cref="CarWash"/> to insert.</param>
        public bool Insert(CarWash carWash)
        {
            if (carWash.IsValid)
            {
                _carWashes.Add(carWash);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Get list of car washes.
        /// </summary>
        /// <returns><see cref="IEnumerable{T}"/></returns>
        public IEnumerable<CarWash> GetAll()
        {
            return _carWashes;
        }

        /// <summary>
        /// Get car wash by id.
        /// </summary>
        /// <param name="id">Id of <see cref="CarWash"/>.</param>
        /// <returns><see cref="CarWash"/></returns>
        public CarWash GetById(int id)
        {
            return _carWashes.Where(x => x.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Update existing car wash in repository. If it doesn't exist; insert it.
        /// </summary>
        /// <param name="carWash"><see cref="CarWash"/> to update (or insert).</param>
        public void Update(CarWash carWash)
        {
            CarWash carWashToUpdate = _carWashes.Where(x => x.Id == carWash.Id).FirstOrDefault();
            if (carWashToUpdate != null && carWash.IsValid)
                carWashToUpdate = carWash;
            else
                Insert(carWash);
        }

        /// <summary>
        /// Delete car wash with given id.
        /// </summary>
        /// <param name="id">Id of <see cref="CarWash"/>.</param>
        public void Delete(int id)
        {
            _carWashes.RemoveAll(x => x.Id == id);
        }
    }
}
