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
            return _tickets.Where(x => x.TicketId == id).FirstOrDefault();
        }

        /// <summary>
        /// Update existing ticket in repository. If it doesn't exist; insert it.
        /// </summary>
        /// <param name="ticket"><see cref="Ticket"/> to update (or insert).</param>
        public void Update(Ticket ticket)
        {
            Ticket ticketToUpdate = _tickets.Where(x => x.TicketId == ticket.TicketId).FirstOrDefault();
            if (ticketToUpdate == null)
                Insert(ticket);
            else
                ticketToUpdate = ticket;
        }

        /// <summary>
        /// Delete ticket with given id.
        /// </summary>
        /// <param name="id">Id of <see cref="Ticket"/>.</param>
        public void Delete(int id)
        {
            _tickets.RemoveAll(x => x.TicketId == id);
        }

        /// <summary>
        /// Validate ticket.
        /// </summary>
        /// <param name="ticket"><see cref="Ticket"/> to validate.</param>
        /// <returns>True if valid; otherwise false.</returns>
        public bool Validate(Ticket ticket)
        {
            bool isValid = true;
            
            if (ticket.StartTime != null) isValid = false;
            if (ticket.ParkingSlot != null) isValid = false;
            
            return isValid;
        }

        public void Save()
        {
            // TODO: Save changes made in repository.
        }
    }
}
