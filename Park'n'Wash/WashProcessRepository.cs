using Park_n_Wash.Wash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash
{
    class WashProcessRepository : IRepository<IWashProcess>
    {
        private List<IWashProcess> _washProcesses;

        public WashProcessRepository()
        {
            _washProcesses = new List<IWashProcess>();
        }

        /// <summary>
        /// Add wash process to repository.
        /// </summary>
        /// <param name="washProcess"><see cref="IWashProcess"/> to insert.</param>
        public void Insert(IWashProcess washProcess)
        {
            if (washProcess.IsValid)
                _washProcesses.Add(washProcess);
        }

        /// <summary>
        /// Get list of wash processes.
        /// </summary>
        /// <returns><see cref="IEnumerable{T}"/></returns>
        public IEnumerable<IWashProcess> GetAll()
        {
            return _washProcesses;
        }

        /// <summary>
        /// Get wash process by id.
        /// </summary>
        /// <param name="id">Id of <see cref="IWashProcess"/>.</param>
        /// <returns><see cref="IWashProcess"/></returns>
        public IWashProcess GetById(int id)
        {
            return _washProcesses.Where(x => x.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Update existing wash process in repository. If it doesn't exist; insert it.
        /// </summary>
        /// <param name="wash"><see cref="IWashProcess"/> to update (or insert).</param>
        public void Update(IWashProcess washProcess)
        {
            IWashProcess washProcessToUpdate = _washProcesses.Where(x => x.Id == washProcess.Id).FirstOrDefault();
            if (washProcessToUpdate != null && washProcess.IsValid)
                washProcessToUpdate = washProcess;
            else
                Insert(washProcess);
        }

        /// <summary>
        /// Delete wash with given id.
        /// </summary>
        /// <param name="id">Id of <see cref="IWashProcess"/>.</param>
        public void Delete(int id)
        {
            _washProcesses.RemoveAll(x => x.Id == id);
        }
    }
}
