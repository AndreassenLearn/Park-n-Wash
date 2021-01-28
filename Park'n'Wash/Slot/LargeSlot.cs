using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash.Slot
{
    class LargeSlot : Slot
    {
        public LargeSlot(int slotId) : base(slotId)
        {
            PricePrHour = 21.5;
        }
    }
}
