using Park_n_Wash.Slot;
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
        /// Create <see cref="ITicket"/> for free <see cref="ISlot"/>.
        /// </summary>
        /// <param name="slot"><see cref="ISlot"/> to occupy.</param>
        /// <param name="electric">Weather to include electric charging.</param>
        /// <param name="service">Weather to inlcude service.</param>
        /// <param name="ticket"><see cref="ITicket"/> ready to be registered.</param>
        /// <param name="_slotController"><see cref="SlotController"/> to occupy <see cref="ISlot"/>.</param>
        /// <returns>True if ticket was successfully created; otherwise false (and <see cref="ITicket"/> will be null).</returns>
        public bool NewSlotTicket(ISlot slot, bool electric, bool service, out ITicket ticket, SlotController _slotController)
        {
            ticket = null;

            if (electric && !slot.HasCharger)
                return false;

            if (_slotController.OccupyIfFree(slot))
            {
                if (service)
                    ticket = new ServiceTicket(GetNextId(), slot, electric);
                else
                    ticket = new BasicTicket(GetNextId(), slot, electric);

                return true;
            }

            return false;
        }

        public void CheckOutSlotTicket(ISlotTicket ticket, SlotController slotController)
        {
            ticket.CheckOut(slotController);
            _ticketRepository.Update(ticket);
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
        /// Get <see cref="IWashTicket"/> by ID.
        /// </summary>
        /// <param name="id">ID of <see cref="IWashTicket"/>.</param>
        /// <returns><see cref="IWashTicket"/> with ID; otherwise null.</returns>
        public IWashTicket GetWashTicketById(int id)
        {
            return _ticketRepository.GetById(id) as IWashTicket; //ticket will be null if it's not an IWashTicket or it doesn't exist.
        }

        /// <summary>
        /// Get <see cref="ISlotTicket"/> by ID.
        /// </summary>
        /// <param name="id">ID of <see cref="ISlotTicket"/>.</param>
        /// <returns><see cref="ISlotTicket"/> with ID; otherwise null.</returns>
        public ISlotTicket GetSlotTicketById(int id)
        {
            return _ticketRepository.GetById(id) as ISlotTicket;
        }
    }
}
