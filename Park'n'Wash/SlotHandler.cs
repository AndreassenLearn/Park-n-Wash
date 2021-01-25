using System;
using System.Collections.Generic;
using System.Text;

namespace Park_n_Wash
{
    class SlotHandler
    {
        private readonly int _normalSlotCount = 50;
        private readonly int _handicapSlotCount = 5;
        private readonly int _largeSlotCount = 12;
        private readonly int _trailerSlotCount = 10;

        public enum SlotTypes
        {
            Normal = 0,
            Handicap,
            Large,
            Trailer
        }

        private List<ISlot> NormalSlots { get; set; }
        private List<ISlot> HandicapSlots { get; set; }
        private List<ISlot> LargeSlots { get; set; }
        private List<ISlot> TrailerSlots { get; set; }

        public SlotHandler()
        {
            Initialize();
        }

        public List<ISlot> GetAvailableSlots(SlotTypes slotType)
        {
            switch (slotType)
            {
                case SlotTypes.Normal:
                    return NormalSlots;
                case SlotTypes.Handicap:
                    return HandicapSlots;
                case SlotTypes.Large:
                    return LargeSlots;
                case SlotTypes.Trailer:
                    return TrailerSlots;
                default:
                    return new List<ISlot>();
            }
        }

        private void Initialize()
        {
            int id = 0;
            NormalSlots = new List<ISlot>();
            HandicapSlots = new List<ISlot>();
            LargeSlots = new List<ISlot>();
            TrailerSlots = new List<ISlot>();

            for (int i = 0; i < _normalSlotCount; i++)
            {
                NormalSlots.Add(new NormalSlot(id++));
            }

            for (int i = 0; i < _handicapSlotCount; i++)
            {
                HandicapSlots.Add(new HandicapSlot(id++));
            }

            for (int i = 0; i < _largeSlotCount; i++)
            {
                LargeSlots.Add(new LargeSlot(id++));
            }

            for (int i = 0; i < _trailerSlotCount; i++)
            {
                TrailerSlots.Add(new TrailerSlot(id++));
            }
        }
    }
}
