using System;
using System.Collections.Generic;
using System.Text;

namespace Park_n_Wash
{
    public abstract class Slot<T> : ISlot
    {
        public int SlotId { get; }
        public bool IsFree { get; set; }
        public double PricePrHour { get; protected set; }

        public Slot(int slotId)
        {
            SlotId = slotId;
            IsFree = true;
        }
    }
}
