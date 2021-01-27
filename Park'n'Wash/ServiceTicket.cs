using System;
using System.Collections.Generic;
using System.Text;

namespace Park_n_Wash
{
    class ServiceTicket : Ticket
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
