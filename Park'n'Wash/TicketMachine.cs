using System;
using System.Collections.Generic;
using System.Text;

namespace Park_n_Wash
{
    class TicketMachine
    {
        private SlotHandler _slotHandler = new SlotHandler();

        /// <summary>
        /// Run application UI, wait for user input and act accordingly.
        /// </summary>
        public void RunApplication()
        {
            Console.WriteLine("##### Welcome to Park'n'Wash #####");
            
            _slotHandler.GetAvailableSlots(out List<ISlot> normalSlots, out List<ISlot> handicapSlots, out List<ISlot> largeSlots, out List<ISlot> trailerSlots);

            Console.WriteLine("##### Available parking slots #####" +
                "\n1. Regular slots: " + normalSlots.Count +
                "\n2. Handicap slots: " + handicapSlots.Count +
                "\n3. Large slots (bus/lorry): " + largeSlots.Count +
                "\n4. Trailer slots: " + trailerSlots.Count);

            switch (UserInteraction.GetInt(1, 4))
            {
                case 1:

                    break;
            }
        }
    }
}
