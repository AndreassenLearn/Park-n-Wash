using Park_n_Wash.Slot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash.Ticket
{
    class ServiceTicket : SlotTicket
    {
        private double _servicePrice = 479.99;

        public bool ServiceDone { get; set; }

        public ServiceTicket(int ticketId, ISlot parkingSlot) : base(ticketId, parkingSlot)
        {
            ServiceDone = false;
            Price += _servicePrice;
        }

        public override void CheckOut()
        {
            if (ServiceDone)
                base.CheckOut();
        }
    }
}
