using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash.Wash
{
    abstract class WashProcess : BusinessEntity, IWashProcess
    {
        public int Id { get; private set; }

        public override bool Validate()
        {
            bool isValid = true;

            return isValid;
        }
    }
}
