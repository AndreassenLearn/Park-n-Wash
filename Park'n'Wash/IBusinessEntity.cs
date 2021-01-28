using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash
{
    public enum EntityStateOption
    {
        Active,
        Deleted
    }

    public interface IBusinessEntity
    {
        public int Id { get; }
        public EntityStateOption EntityState { get; }
        public bool HasChanges { get; }
        public bool IsNew { get; }
        public bool IsValid { get; }

        /// <summary>
        /// Check whether <see cref="IBusinessEntity"/> meets reqirements to be valid.
        /// </summary>
        /// <returns>True if valid; otherwise false.</returns>
        bool Validate();
    }
}
