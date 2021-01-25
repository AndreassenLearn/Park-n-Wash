using System;
using System.Collections.Generic;
using System.Text;

namespace Park_n_Wash
{
    class TicketMachine
    {
        private SlotHandler SlotHandler { get; set; }

        public TicketMachine() => SlotHandler = new SlotHandler();

        public void ListSlots(out List<ISlot> normalSlots, out List<ISlot> handicapSlots, out List<ISlot> largeSlots, out List<ISlot> trailerSlots)
        {
            normalSlots = SlotHandler.GetAvailableSlots(SlotHandler.SlotTypes.Normal);
            handicapSlots = SlotHandler.GetAvailableSlots(SlotHandler.SlotTypes.Handicap);
            largeSlots = SlotHandler.GetAvailableSlots(SlotHandler.SlotTypes.Large);
            trailerSlots = SlotHandler.GetAvailableSlots(SlotHandler.SlotTypes.Trailer);
        }
    }
}
