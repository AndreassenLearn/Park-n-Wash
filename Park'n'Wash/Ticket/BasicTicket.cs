using Park_n_Wash.Slot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash.Ticket
{
    class BasicTicket : SlotTicket
    {
        public BasicTicket(int ticketId, ISlot parkingSlot, bool includeCharging) : base(ticketId, parkingSlot, includeCharging)
        {

        }
    }
}
