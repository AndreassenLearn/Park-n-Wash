using System;
using System.Collections.Generic;
using System.Text;

namespace Park_n_Wash
{
    class LargeSlot : Slot
    {
        public LargeSlot(int slotId) : base(slotId)
        {
            PricePrHour = 21.5;
        }
    }
}
