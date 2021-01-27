using System;
using System.Collections.Generic;
using System.Text;

namespace Park_n_Wash
{
    public interface ITicket : IBusinessEntity
    {
        public DateTime StartTime { get; }
        public ISlot ParkingSlot { get; }
        public bool Electric { get; }

        public void CheckOut();
    }
}
