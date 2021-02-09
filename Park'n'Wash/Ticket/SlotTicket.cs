using Park_n_Wash.Slot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash.Ticket
{
    public abstract class SlotTicket : BusinessEntity, ISlotTicket
    {
        public int Id { get; }
        public DateTime StartTime { get; }
        public DateTime? EndTime { get; private set; }
        public double TotalHours { get; private set; }
        public ISlot ParkingSlot { get; }
        public bool Electric { get; }
        public double Price { get; protected set; }

        public SlotTicket(int ticketId, ISlot parkingSlot, bool includeCharging = false)
        {
            Id = ticketId;
            StartTime = DateTime.Now;
            TotalHours = 0;
            ParkingSlot = parkingSlot;
            Electric = includeCharging && ParkingSlot.HasCharger;
            Price = 0;
        }

        /// <summary>
        /// Calculate price, free parking slot, mark as deleted, and validate.
        /// </summary>
        /// <param name="slotController"><see cref="SlotController"/> to free parking slot.</param>
        /// <returns>True if successful; otherwise false.</returns>
        public virtual bool CheckOut(SlotController slotController)
        {
            bool success = true;
            
            // Calculate price.
            EndTime = DateTime.Now;
            TotalHours = (EndTime.Value - StartTime).TotalHours;
            Price += ParkingSlot.PricePrHour * TotalHours;

            // Free parking slot.
            success &= slotController.Free(ParkingSlot);

            // Mark ticket as deleted.
            EntityState = EntityStateOption.Deleted;

            // Validate.
            return success &= Validate();
        }

        public string PrintableString() =>
            $"# ##\n" +
            $"# ##  Ticket: {Id} Slot: {ParkingSlot.Id}\n" +
            $"# ##\n" +
            $"# ##  Start Time: {StartTime} - End Time: {(EndTime.HasValue ? EndTime.Value.ToString() : "N/A")}\n" +
            $"# ##  Total hours: {TotalHours}\n" +
            $"# ##  Charging: {(Electric? "Y" : "N")}\n" +
            $"# ##\n" +
            $"# ##  Price: {Price} kr.\n" +
            $"# ##\n\n";

        public override bool Validate()
        {
            bool isValid = true;

            if (StartTime == null) isValid = false;
            if (ParkingSlot == null) isValid = false;
            if (Electric && !ParkingSlot.HasCharger) isValid = false;
            if (Price < 0) isValid = false;

            return isValid;
        }
    }
}
