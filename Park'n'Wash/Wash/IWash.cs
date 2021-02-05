using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash.Wash
{
    interface IWash
    {
        public List<IWashProcess> WashProcesses { get; }
    }
}
