using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash.Slot
{
    class TrailerSlot : Slot
    {
        public TrailerSlot(int slotId) : base(slotId)
        {
            PricePrHour = 8.7;
        }
    }
}
