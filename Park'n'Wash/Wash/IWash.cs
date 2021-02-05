using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash.Wash
{
    public interface IWash : IBusinessEntity
    {
        public string Name { get; }
        public double Price { get; }
        public List<IWashProcess> WashProcesses { get; }
    }
}
