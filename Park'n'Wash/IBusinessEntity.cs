using System;
using System.Collections.Generic;
using System.Text;

namespace Park_n_Wash
{
    public interface IBusinessEntity
    {
        public int Id { get; }

        /// <summary>
        /// Check whether <see cref="IBusinessEntity"/> meets reqirements to be valid.
        /// </summary>
        /// <returns>True if valid; otherwise false.</returns>
        bool Validate();
    }
}
