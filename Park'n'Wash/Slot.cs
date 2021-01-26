using System;
using System.Collections.Generic;
using System.Text;

namespace Park_n_Wash
{
    public abstract class Slot<T> : ISlot
    {
        public int Id { get; }
        public bool IsFree { get; set; }
        public double PricePrHour { get; protected set; }

        public Slot(int slotId)
        {
            Id = slotId;
            IsFree = true;
        }

        public bool IsValid()
        {
            bool isValid = true;

            if (PricePrHour < 0) isValid = false;

            return isValid;
        }
    }
}
