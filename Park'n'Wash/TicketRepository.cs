﻿using Park_n_Wash.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash
{
    class TicketRepository : IRepository<ITicket>
    {
        private List<ITicket> _tickets;

        public TicketRepository()
        {
            _tickets = new List<ITicket>();
        }
        
        /// <summary>
        /// Add ticket to repository.
        /// </summary>
        /// <param name="ticket"><see cref="Ticket"/> to insert.</param>
        public bool Insert(ITicket ticket)
        {
            if (ticket.IsValid)
            {
                _tickets.Add(ticket);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Get list of tickets.
        /// </summary>
        /// <returns><see cref="IEnumerable{T}"/></returns>
        public IEnumerable<ITicket> GetAll()
        {
            return _tickets;
        }

        /// <summary>
        /// Get ticket by id.
        /// </summary>
        /// <param name="id">Id of <see cref="Ticket"/>.</param>
        /// <returns><see cref="Ticket"/></returns>
        public ITicket GetById(int id)
        {
            return _tickets.Where(x => x.Id == id && x.EntityState.Equals(EntityStateOption.Active)).FirstOrDefault();
        }

        /// <summary>
        /// Update existing ticket in repository. If it doesn't exist; insert it.
        /// </summary>
        /// <param name="ticket"><see cref="Ticket"/> to update (or insert).</param>
        public bool Update(ITicket ticket)
        {
            ITicket ticketToUpdate = _tickets.Where(x => x.Id == ticket.Id).FirstOrDefault();
            if (ticketToUpdate != null && ticket.IsValid)
            {
                ticketToUpdate = ticket;
                return true;
            }
            else
            {
                return Insert(ticket);
            }
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
