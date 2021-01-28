using Park_n_Wash.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Park_n_Wash
{
    class TicketMachine
    {
        private SlotHandler _slotHandler;
        private TicketRepository _ticketRepository;

        public TicketMachine()
        {
            _slotHandler = new SlotHandler();
            _ticketRepository = new TicketRepository();
        }

        /// <summary>
        /// Run application UI, wait for user input and act accordingly.
        /// </summary>
        public void RunApplication()
        {
            Console.WriteLine("Welcome to Park'n'Wash\n");

            int userOption = UserInteraction.SelectOption(new List<string> { "Chech In", "Check Out" });

            if (userOption == 0)
            {
                // Check in.
                _slotHandler.GetAvailableSlots(out List<ISlot> normalSlots, out List<ISlot> handicapSlots, out List<ISlot> largeSlots, out List<ISlot> trailerSlots);

                userOption = UserInteraction.SelectOption(
                    new List<string> { 
                        "Regular slots: " + normalSlots.Count + "(" + _slotHandler.ElectricCountAndSort(normalSlots) + " of which offers electric charging)",
                        "Handicap slots: " + handicapSlots.Count,
                        "Large slots (bus/lorry): " + largeSlots.Count,
                        "Trailer slots: " + trailerSlots.Count
                    },
                    "Available parking slots");
            }
            else if (userOption == 1)
            {
                // Check out.

            }
        }
    }
}
