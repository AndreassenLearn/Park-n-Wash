using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash
{
    class TicketController
    {
        private TicketRepository _ticketRepository;

        public TicketController()
        {
            _ticketRepository = new TicketRepository();
        }


    }
}
