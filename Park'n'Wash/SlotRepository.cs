﻿using Park_n_Wash.Slot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash
{
    class SlotRepository : IRepository<ISlot>
    {
        private List<ISlot> _slots;

        public SlotRepository()
        {
            _slots = new List<ISlot>();
        }

        /// <summary>
        /// Add slot to repository.
        /// </summary>
        /// <param name="slot"><see cref="Slot"/> to insert.</param>
        public bool Insert(ISlot slot)
        {
            if (slot.IsValid)
            {
                _slots.Add(slot);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Get list of slots.
        /// </summary>
        /// <returns><see cref="IEnumerable{T}"/></returns>
        public IEnumerable<ISlot> GetAll()
        {
            return _slots;
        }

        /// <summary>
        /// Get list of available slots of specific type.
        /// </summary>
        /// <returns><see cref="IEnumerable{T}"/></returns>
        public IEnumerable<ISlot> GetAllAvailableByType(Type type)
        {
            return _slots.Where(x => x.IsFree && x.GetType().Equals(type));
        }

        /// <summary>
        /// Get slot by id.
        /// </summary>
        /// <param name="id">Id of <see cref="ISlot"/>.</param>
        /// <returns><see cref="ISlot"/></returns>
        public ISlot GetById(int id)
        {
            return _slots.Where(x => x.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Update existing slot in repository. If it doesn't exist; insert it.
        /// </summary>
        /// <param name="slot"><see cref="ISlot"/> to update (or insert).</param>
        public bool Update(ISlot slot)
        {
            ISlot slotToUpdate = _slots.Where(x => x.Id == slot.Id).FirstOrDefault();
            if (slotToUpdate != null && slot.IsValid)
            {
                slotToUpdate = slot;
                return true;
            }
            else
            {
                return Insert(slot);
            }
        }

        /// <summary>
        /// Delete slot with given id.
        /// </summary>
        /// <param name="id">Id of <see cref="ISlot"/>.</param>
        public void Delete(int id)
        {
            _slots.RemoveAll(x => x.Id == id);
        }
    }
}
