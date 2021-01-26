using System;
using System.Collections.Generic;
using System.Text;

namespace Park_n_Wash
{
    class Ticket
    {
        public int TicketId { get; private set; }
        public DateTime StartTime { get; set; }
        public ISlot ParkingSlot { get; set; }
    }
}
