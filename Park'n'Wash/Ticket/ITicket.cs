using Park_n_Wash.Slot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash.Ticket
{
    public interface ITicket : IBusinessEntity
    {
        public DateTime StartTime { get; }
        public ISlot ParkingSlot { get; }
        public bool Electric { get; }

        public void CheckOut();
    }
}
