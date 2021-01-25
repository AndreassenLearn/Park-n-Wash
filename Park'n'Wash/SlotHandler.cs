using System;
using System.Collections.Generic;
using System.Text;

namespace Park_n_Wash
{
    class SlotHandler
    {
        public enum SlotTypes
        {
            Normal = 0,
            Handicap,
            Large,
            Trailer
        }

        private List<NormalSlot> NormalSlots { get; set; }
        private List<HandicapSlot> HandicapSlots { get; set; }
        private List<LargeSlot> LargeSlots { get; set; }
        private List<TrailerSlot> TrailerSlots { get; set; }

        private int NormalSlotCount = 50;
        private int HandicapSlotCount = 5;
        private int LargeSlotCount = 12;
        private int TrailerSlotCount = 10;
        
        SlotHandler()
        {
            Initialize();
        }

        public List<ISlot> GetAvailableSlots(string slotType)
        {
            Type type = Type.GetType(slotType);



            return new List<ISlot>();
        }

        private void Initialize()
        {
            int id = 0;
            NormalSlots = new List<NormalSlot>();
            HandicapSlots = new List<HandicapSlot>();
            LargeSlots = new List<LargeSlot>();
            TrailerSlots = new List<TrailerSlot>();

            for (int i = 0; i < NormalSlotCount; i++)
            {
                NormalSlots.Add(new NormalSlot(id++));
            }

            for (int i = 0; i < HandicapSlotCount; i++)
            {
                HandicapSlots.Add(new HandicapSlot(id++));
            }

            for (int i = 0; i < LargeSlotCount; i++)
            {
                LargeSlots.Add(new LargeSlot(id++));
            }

            for (int i = 0; i < TrailerSlotCount; i++)
            {
                TrailerSlots.Add(new TrailerSlot(id++));
            }
        }
    }
}
