using Park_n_Wash.Wash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash.Ticket
{
    public interface IWashTicket : ITicket
    {
        public IWash Wash { get; }
        bool HasWashed { get; set; }
    }
}
