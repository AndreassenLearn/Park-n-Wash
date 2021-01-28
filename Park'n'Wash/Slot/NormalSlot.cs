using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash.Slot
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
