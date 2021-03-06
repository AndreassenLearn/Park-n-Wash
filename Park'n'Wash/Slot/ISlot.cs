﻿using Park_n_Wash.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash.Slot
{
    public interface ISlot : IBusinessEntity, IPrintable
    {
        bool IsFree { get; set; }
        double PricePrHour { get; }
        bool HasCharger { get; }
    }
}
