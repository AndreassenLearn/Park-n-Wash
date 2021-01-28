using System;
using System.Collections.Generic;
using System.Text;

namespace Park_n_Wash
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
