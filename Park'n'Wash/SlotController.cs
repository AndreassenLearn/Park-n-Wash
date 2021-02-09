using Park_n_Wash.Slot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash
{
    class SlotController
    {
        private readonly int _normalSlotCount = 50;
        private readonly int _handicapSlotCount = 5;
        private readonly int _largeSlotCount = 12;
        private readonly int _trailerSlotCount = 10;

        private SlotRepository _slotRepository;

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

        public SlotController()
        {
            _slotRepository = new SlotRepository();
            Initialize();
        }

        /// <summary>
        /// Get free parking slots of a specific type.
        /// </summary>
        /// <returns>List of free parking slots.</returns>
        public List<ISlot> GetAvailableSlotsByType(SlotTypes slotType)
        {
            return slotType switch
            {
                SlotTypes.Normal => _slotRepository.GetAllAvailableByType(typeof(NormalSlot)).ToList(),
                SlotTypes.Handicap => _slotRepository.GetAllAvailableByType(typeof(HandicapSlot)).ToList(),
                SlotTypes.Large => _slotRepository.GetAllAvailableByType(typeof(LargeSlot)).ToList(),
                SlotTypes.Trailer => _slotRepository.GetAllAvailableByType(typeof(TrailerSlot)).ToList(),
                _ => new List<ISlot>(),
            };
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
            normalSlots = GetAvailableSlotsByType(SlotTypes.Normal);
            handicapSlots = GetAvailableSlotsByType(SlotTypes.Handicap);
            largeSlots = GetAvailableSlotsByType(SlotTypes.Large);
            trailerSlots = GetAvailableSlotsByType(SlotTypes.Trailer);
        }

        /// <summary>
        /// Count electric slots and sort list with electric slots in the end.
        /// </summary>
        /// <param name="slots">Slots to count in and sort.</param>
        /// <returns>Number of electric slots.</returns>
        public int ElectricCountAndSort(List<ISlot> slots)
        {
            List<ISlot> electricSlots = slots.Where(x => x.HasCharger).ToList();
            slots.RemoveAll(x => x.HasCharger);
            slots.AddRange(electricSlots);

            return electricSlots.Count;
        }

        /// <summary>
        /// Set <see cref="ISlot.IsFree"/> to false if slot is free.
        /// </summary>
        /// <param name="slot"><see cref="ISlot"/> to modify.</param>
        /// <returns>True if successful; otherwise false.</returns>
        public bool OccupyIfFree(ISlot slot)
        {
            if (_slotRepository.GetById(slot.Id).IsFree)
            {
                slot.IsFree = false;
                return _slotRepository.Update(slot);
            }

            return false;
        }

        /// <summary>
        /// Initialize parking slot lists with new empty parking slots.
        /// </summary>
        private void Initialize()
        {
            int id = 0;
            for (int i = 0; i < _normalSlotCount; i++)
            {
                _slotRepository.Insert(new NormalSlot(id++));
            }

            for (int i = 0; i < _handicapSlotCount; i++)
            {
                _slotRepository.Insert(new HandicapSlot(id++));
            }

            for (int i = 0; i < _largeSlotCount; i++)
            {
                _slotRepository.Insert(new LargeSlot(id++));
            }

            for (int i = 0; i < _trailerSlotCount; i++)
            {
                _slotRepository.Insert(new TrailerSlot(id++));
            }
        }
    }
}
