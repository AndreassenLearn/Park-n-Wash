using System;
using System.Collections.Generic;
using System.Text;

namespace Park_n_Wash
{
    class TicketMachine
    {
        private readonly Dictionary<SlotTypes, string> slotTypeNames = new Dictionary<SlotTypes, string>
        {
            { SlotTypes.Normal, "NormalSlot" },
            { SlotTypes.Handicap, "HandicapSlot" },
            { SlotTypes.Large, "LargeSlot" },
            { SlotTypes.Trailer, "TrailerSlot" }
        };
        
        private SlotHandler slotHandler = new SlotHandler();

        public void ListSlots()
        {
            List<ISlot> normalSlots = slotHandler.GetAvailableSlots(slotTypeNames[SlotTypes.Normal]);
            List<ISlot> handicapSlots = slotHandler.GetAvailableSlots(slotTypeNames[SlotTypes.Handicap]);
            List<ISlot> largeSlots = slotHandler.GetAvailableSlots(slotTypeNames[SlotTypes.Large]);
            List<ISlot> trailerSlots = slotHandler.GetAvailableSlots(slotTypeNames[SlotTypes.Trailer]);
        }
    }
}
