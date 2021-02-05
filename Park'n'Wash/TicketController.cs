using Park_n_Wash.Ticket;
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
        private int _newTicketId;

        public TicketController()
        {
            _ticketRepository = new TicketRepository();
            _newTicketId = 0;
        }

        public int NextId()
        {
            return _newTicketId++;
        }

        public bool AddTicket(ITicket ticket)
        {
            return _ticketRepository.Insert(ticket);
        }
    }
}
