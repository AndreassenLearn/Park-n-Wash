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

        /// <summary>
        /// Defines the type of a parking slot.
        /// </summary>
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

        /// <summary>
        /// Get free parking slots of a specific type.
        /// </summary>
        /// <returns>List of free parking slots.</returns>
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

        /// <summary>
        /// Get all free parking slots.
        /// </summary>
        /// <param name="normalSlots">List to contain normal parking slots.</param>
        /// <param name="handicapSlots">List to contain handicap parking slots.</param>
        /// <param name="largeSlots">List to contain large parking slots.</param>
        /// <param name="trailerSlots">List to contain trailer parking slots.</param>
        public void GetAvailableSlots(out List<ISlot> normalSlots, out List<ISlot> handicapSlots, out List<ISlot> largeSlots, out List<ISlot> trailerSlots)
        {
            normalSlots = NormalSlots;
            handicapSlots = HandicapSlots;
            largeSlots = LargeSlots;
            trailerSlots = TrailerSlots;
        }

        /// <summary>
        /// Initialize parking slot lists with new empty parking slots.
        /// </summary>
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
