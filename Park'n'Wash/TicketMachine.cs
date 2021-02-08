using Park_n_Wash.Common;
using Park_n_Wash.Slot;
using Park_n_Wash.Ticket;
using Park_n_Wash.Wash;
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
            _washController = new WashController();
        }

        /// <summary>
        /// Run application UI, wait for user input and act accordingly.
        /// </summary>
        public void RunApplication()
        {
            while (true)
            {
                ConsoleService.Clear();
                Console.WriteLine("Welcome to Park'n'Wash\n");

                UserOption option = (UserOption)UserInteraction.SelectOption(new List<IPrintable>()
                {
                    new UserOption("Park: Check In", new UserOption.OptionFunction(TicketMachine.ParkCheckIn)),
                    new UserOption("Park: Check Out", new UserOption.OptionFunction(TicketMachine.ParkCheckOut)),
                    new UserOption("Wash: Order", new UserOption.OptionFunction(TicketMachine.WashOrder)),
                    new UserOption("Wash: Start", new UserOption.OptionFunction(TicketMachine.WashStart)),
                    new UserOption("Wash: Cancel", new UserOption.OptionFunction(TicketMachine.WashCancel)),
                    new UserOption("Wash: Inspect", new UserOption.OptionFunction(TicketMachine.WashInspect))
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
            List<IPrintable> options = new List<IPrintable>();
            int nextId = _ticketController.GetNextId();
            foreach (IWash wash in _washController.GetWashes())
            {
                options.Add(new UserOption($"{wash.Name} - {wash.Price} kr.", new UserOption.OptionFunctionTicket(TicketMachine.RegisterNewTicket), new WashTicket(nextId, wash)));
            }
            
            UserOption option = (UserOption)UserInteraction.SelectOption(options, "Choose wash type");
            option.Execute();
        }

        public static void WashStart()
        {
            int id = UserInteraction.GetInt("Start Wash", "Enter ticket ID");
            IWashTicket ticket = _ticketController.GetUnusedWashTicketById(id);
            if (ticket != null)
            {
                if (!_washController.StartCarWash(ticket))
                    Console.WriteLine("Unable to start wash. Has this ticket has already been used?");
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }

        public static void WashCancel()
        {
            int id = UserInteraction.GetInt("Cancel Wash", "Enter car wash number");
            if (!_washController.CancelCarWash(id))
                Console.WriteLine($"Unable to cancel. Is the car wash #{id} running?");
        }

        public static void WashInspect()
        {
            ConsoleService.PrintToConsole(_washController.GetPrintableCarWashes());
        }

        public static void RegisterNewTicket(ITicket ticket)
        {
            _ticketController.AddTicket(ticket);

            (ticket as IPrintable).PrintToConsole();
        }
    }
}
