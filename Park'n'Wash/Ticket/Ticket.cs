using System;
using System.Collections.Generic;
using System.Text;

namespace Park_n_Wash
{
    abstract class Ticket : BusinessEntity, ITicket
    {
        public int Id { get; }
        public DateTime StartTime { get; }
        public DateTime EndTime { get; private set; }
        public ISlot ParkingSlot { get; }
        public bool Electric { get; }
        public double Price { get; protected set; }

        public Ticket(int ticketId, ISlot parkingSlot, bool includeCharging = false)
        {
            Id = ticketId;
            StartTime = DateTime.Now;
            ParkingSlot = parkingSlot;
            Electric = includeCharging && ParkingSlot.HasCharger;
            Price = 0;
        }

        /// <summary>
        /// Calculate price, free parking slot, and mark as deleted.
        /// </summary>
        public virtual void CheckOut()
        {
            // Calculate price.
            EndTime = DateTime.Now;
            double hours = (EndTime - StartTime).TotalHours;
            Price += ParkingSlot.PricePrHour * hours;

            // TODO: Free parking slot.

            // Mark ticket as deleted.
            EntityState = EntityStateOption.Deleted;
        }

        public override bool Validate()
        {
            bool isValid = true;

            if (StartTime == null) isValid = false;
            if (ParkingSlot == null) isValid = false;
            if (!(Electric && ParkingSlot.HasCharger)) isValid = false;
            if (Price < 0) isValid = false;

            return isValid;
        }
    }
}
