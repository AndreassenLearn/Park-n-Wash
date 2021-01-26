using System;
using System.Collections.Generic;
using System.Text;

namespace Park_n_Wash
{
    class Ticket : IBusinessEntity
    {
        public int Id { get; private set; }
        public DateTime StartTime { get; set; }
        public ISlot ParkingSlot { get; set; }

        public bool IsValid()
        {
            bool isValid = true;

            if (StartTime != null) isValid = false;
            if (ParkingSlot != null) isValid = false;

            return isValid;
        }
    }
}
