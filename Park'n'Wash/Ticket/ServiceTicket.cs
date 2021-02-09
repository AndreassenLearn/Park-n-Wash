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

        public ServiceTicket(int ticketId, ISlot parkingSlot, bool includeCharging) : base(ticketId, parkingSlot, includeCharging)
        {
            ServiceDone = false;
            Price += _servicePrice;
        }

        /// <summary>
        /// Check out ticket only if service is done.
        /// </summary>
        /// <param name="slotController"><see cref="SlotController"/> to free parking slot.</param>
        /// <returns>True if successful; otherwise false.</returns>
        public override bool CheckOut(SlotController slotController)
        {
            if (ServiceDone)
                return base.CheckOut(slotController);

            return false;
        }
    }
}
