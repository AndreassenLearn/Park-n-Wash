using Park_n_Wash.Slot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash.Ticket
{
    class WashTicket : Ticket
    {
        public bool HasWashed { get; set; }

        public WashTicket(int ticketId, ISlot parkingSlot) : base(ticketId, parkingSlot)
        {
            HasWashed = false;
        }
    }
}
