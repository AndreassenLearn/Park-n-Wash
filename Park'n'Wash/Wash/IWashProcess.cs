using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash.Wash
{
    public interface IWashProcess : IBusinessEntity
    {
        public string Name { get; }
        public TimeSpan Duration { get; }
    }
}
