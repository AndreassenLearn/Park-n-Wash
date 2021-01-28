using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash.Slot
{
    public abstract class Slot : BusinessEntity, ISlot
    {
        public int Id { get; }
        public bool IsFree { get; set; }
        public double PricePrHour { get; protected set; }
        public bool HasCharger { get; protected set; }

        public Slot(int slotId)
        {
            Id = slotId;
            IsFree = true;
        }

        public override bool Validate()
        {
            bool isValid = true;

            if (PricePrHour < 0) isValid = false;

            return isValid;
        }
    }
}
