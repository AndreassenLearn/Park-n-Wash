using System;
using System.Collections.Generic;
using System.Text;

namespace Park_n_Wash
{
    public interface ISlot : IBusinessEntity
    {
        bool IsFree { get; }
        double PricePrHour { get; }
        bool HasCharger { get; }
    }
}
