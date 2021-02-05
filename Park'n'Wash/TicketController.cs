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

        /// <summary>
        /// Add new ticket.
        /// </summary>
        /// <param name="ticket">Ticket to add.</param>
        /// <returns>True if successful; otherwise false.</returns>
        public bool AddTicket(ITicket ticket)
        {
            return _ticketRepository.Insert(ticket);
        }

        /// <summary>
        /// Get next unique ticket ID.
        /// </summary>
        /// <returns>Unique ID.</returns>
        public int GetNextId()
        {
            return _newTicketId++;
        }

        /// <summary>
        /// Get Ticket by ID.
        /// </summary>
        /// <param name="id">ID of ticket.</param>
        /// <returns>Active <see cref="ITicket"/> with ID; otherwise null.</returns>
        public ITicket GetActiveTicketById(int id)
        {
            ITicket ticket = _ticketRepository.GetById(id);

            if (ticket != null && ticket.EntityState.Equals(EntityStateOption.Active))
                return ticket;

            return null;
        }
    }
}
