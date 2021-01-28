using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash
{
    public abstract class BusinessEntity
    {
        public EntityStateOption EntityState { get; set; }
        public bool HasChanges { get; set; }
        public bool IsNew { get; private set; }
        public bool IsValid => Validate();

        /// <summary>
        /// Check whether <see cref="BusinessEntity"/> meets reqirements to be valid.
        /// </summary>
        /// <returns>True if valid; otherwise false.</returns>
        public abstract bool Validate();
    }
}
