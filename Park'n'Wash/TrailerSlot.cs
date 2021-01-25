using System;
using System.Collections.Generic;
using System.Text;

namespace Park_n_Wash
{
    class TrailerSlot : Slot<int>
    {
        public TrailerSlot(int slotId) : base(slotId)
        {
            PricePrHour = 8.7;
        }
    }
}
