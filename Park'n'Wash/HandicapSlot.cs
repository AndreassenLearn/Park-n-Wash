using System;
using System.Collections.Generic;
using System.Text;

namespace Park_n_Wash
{
    class HandicapSlot : Slot<int>
    {
        public HandicapSlot(int slotId) : base(slotId)
        {
            PricePrHour = 10.0;
        }
    }
}
