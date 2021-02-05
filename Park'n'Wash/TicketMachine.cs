using Park_n_Wash.Common;
using Park_n_Wash.Slot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash
{
    class TicketMachine
    {
        private static SlotController _slotController;
        private static TicketController _ticketController;
        private static WashController _washController;

        public TicketMachine()
        {
            _slotController = new SlotController();
            _ticketController = new TicketController();
        }

        /// <summary>
        /// Run application UI, wait for user input and act accordingly.
        /// </summary>
        public void RunApplication()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Park'n'Wash\n");

                UserOption option = (UserOption)UserInteraction.SelectOption(new List<IPrintable>()
                {
                    new UserOption("Park: Check In", new UserOption.OptionFunction(TicketMachine.ParkCheckIn)),
                    new UserOption("Park: Check Out", new UserOption.OptionFunction(TicketMachine.ParkCheckOut)),
                    new UserOption("Wash: Order", new UserOption.OptionFunction(TicketMachine.WashOrder)),
                    new UserOption("Wash: Start", new UserOption.OptionFunction(TicketMachine.WashStart))
                });
                option.Execute();
            }
        }

        public static void ParkCheckIn()
        {
            _slotController.GetAvailableSlots(out List<ISlot> normalSlots, out List<ISlot> handicapSlots, out List<ISlot> largeSlots, out List<ISlot> trailerSlots);

            //UserOption option = (UserOption)UserInteraction.SelectOption(new List<IPrintable>()
            //{
            //    new UserOption($"Regular slots: {normalSlots.Count} ({_slotController.ElectricCountAndSort(normalSlots)} of which offers electric charging)", new UserOption.OptionFunction(/*FUNCTION DELEGATE*/)),
            //    new UserOption($"Handicap slots: {handicapSlots.Count}", new UserOption.OptionFunction(/*FUNCTION DELEGATE*/)),
            //    new UserOption($"Large slots (bus/lorry): {largeSlots.Count}", new UserOption.OptionFunction(/*FUNCTION DELEGATE*/)),
            //    new UserOption($"Trailer slots: {trailerSlots.Count}", new UserOption.OptionFunction(/*FUNCTION DELEGATE*/))
            //}, "Available parking slots");
            //option.Execute();
        }

        public static void ParkCheckOut()
        {
            
        }

        public static void WashOrder()
        {

        }

        public static void WashStart()
        {

        }
    }
}
