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
        private SlotController _slotController;
        private TicketController _ticketController;

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
            Console.WriteLine("Welcome to Park'n'Wash\n");

            int userOption = UserInteraction.SelectOption(new List<string> { "Chech In", "Check Out" });

            if (userOption == 0)
            {
                // Check in.
                _slotController.GetAvailableSlots(out List<ISlot> normalSlots, out List<ISlot> handicapSlots, out List<ISlot> largeSlots, out List<ISlot> trailerSlots);

                //userOption = UserInteraction.SelectOption(
                //    new List<string> {
                //        "Regular slots: " + normalSlots.Count + " (" + _slotController.ElectricCountAndSort(normalSlots) + " of which offers electric charging)",
                //        "Handicap slots: " + handicapSlots.Count,
                //        "Large slots (bus/lorry): " + largeSlots.Count,
                //        "Trailer slots: " + trailerSlots.Count
                //    },
                //    "Available parking slots");

                UserOption.OptionFunction del = TicketMachine.Test;

                UserOption option = (UserOption)UserInteraction.SelectOption(new List<IPrintable>()
                {
                    new UserOption("First", new UserOption.OptionFunctionSlot(TicketMachine.TestSlot), normalSlots),
                    new UserOption("Second", del)
                },
                "Title");
                option.Execute();
            }
            else if (userOption == 1)
            {
                // Check out.
                
            }
        }

        public static void Test()
        {
            Console.WriteLine("Test");
            System.Threading.Thread.Sleep(10000);
        }

        public static void TestSlot(List<ISlot> slots)
        {
            Console.WriteLine("TestSlot: \n" + slots[0].PrintableString());
            System.Threading.Thread.Sleep(10000);
        }
    }
}
