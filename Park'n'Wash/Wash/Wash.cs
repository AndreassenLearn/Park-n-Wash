using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash.Wash
{
    abstract class Wash : BusinessEntity, IWash
    {
        public int Id { get; private set; }
        public List<IWashProcess> WashProcesses { get; private set; }

        public Wash (int id, List<IWashProcess> washProcesses)
        {
            Id = id;
            WashProcesses = washProcesses;
        }

        public override bool Validate()
        {
            bool isValid = true;

            return isValid;
        }
    }
}
