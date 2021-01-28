using System;
using System.Collections.Generic;
using System.Text;

namespace Park_n_Wash
{
    class TrailerSlot : Slot
    {
        public TrailerSlot(int slotId) : base(slotId)
        {
            PricePrHour = 8.7;
        }
    }
}
