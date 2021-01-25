using System;
using System.Collections.Generic;
using System.Text;

namespace Park_n_Wash
{
    public interface ISlot
    {
        int SlotId { get; }
        bool IsFree { get; }
        double PricePrHour { get; }
    }
}
