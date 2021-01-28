using System;
using System.Collections.Generic;
using System.Text;

namespace Park_n_Wash
{
    class NormalSlot : Slot
    {
        public NormalSlot(int slotId) : base(slotId)
        {
            PricePrHour = 15.5;
            if (slotId <= 20)
                HasCharger = true;
        }
    }
}
