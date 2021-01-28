using System;
using System.Collections.Generic;
using System.Text;

namespace Park_n_Wash
{
    class BasicTicket : Ticket
    {
        public BasicTicket(int ticketId, ISlot parkingSlot, bool includeCharging) : base(ticketId, parkingSlot, includeCharging)
        {

        }
    }
}
