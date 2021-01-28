using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash.Slot
{
    class HandicapSlot : Slot
    {
        public HandicapSlot(int slotId) : base(slotId)
        {
            PricePrHour = 10.0;
        }
    }
}
