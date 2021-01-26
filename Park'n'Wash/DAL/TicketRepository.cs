using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Park_n_Wash.DAL
{
    class TicketRepository : IRepository<Ticket>
    {
        private List<Ticket> _tickets;

        public TicketRepository()
        {
            _tickets = new List<Ticket>();
        }

        /// <summary>
        /// Add ticket to repository.
        /// </summary>
        /// <param name="ticket"><see cref="Ticket"/> to insert.</param>
        public void Insert(Ticket ticket)
        {
            if (ticket.IsValid())
                _tickets.Add(ticket);
        }

        /// <summary>
        /// Get list of tickets.
        /// </summary>
        /// <returns><see cref="List{T}"/></returns>
        public IEnumerable<Ticket> Get()
        {
            return _tickets;
        }
        
        /// <summary>
        /// Get ticket by id.
        /// </summary>
        /// <param name="id">Id of <see cref="Ticket"/>.</param>
        /// <returns><see cref="Ticket"/></returns>
        public Ticket GetById(int id)
        {
            return _tickets.Where(x => x.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Update existing ticket in repository. If it doesn't exist; insert it.
        /// </summary>
        /// <param name="ticket"><see cref="Ticket"/> to update (or insert).</param>
        public void Update(Ticket ticket)
        {
            Ticket ticketToUpdate = _tickets.Where(x => x.Id == ticket.Id).FirstOrDefault();
            if (ticketToUpdate != null && ticket.IsValid())
                ticketToUpdate = ticket;
            else
                Insert(ticket);
        }

        /// <summary>
        /// Delete ticket with given id.
        /// </summary>
        /// <param name="id">Id of <see cref="Ticket"/>.</param>
        public void Delete(int id)
        {
            _tickets.RemoveAll(x => x.Id == id);
        }
    }
}
