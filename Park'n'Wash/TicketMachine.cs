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

        private static Dictionary<int, Task<Dictionary<string, string>>> _washStatistics = new Dictionary<int, Task<Dictionary<string, string>>>();

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
                    new UserOption("Wash: Inspect", new UserOption.OptionFunction(TicketMachine.WashInspect)),
                    new UserOption("Wash: Statistics", new UserOption.OptionFunction(TicketMachine.WashStatistics))
                });
                option.Execute();
            }
        }

        // Park
        public static void ParkCheckIn()
        {
            _slotController.GetAvailableSlots(out List<ISlot> normalSlots, out List<ISlot> handicapSlots, out List<ISlot> largeSlots, out List<ISlot> trailerSlots);

            UserOption option = (UserOption)UserInteraction.SelectOption(new List<IPrintable>()
            {
                new UserOption($"Regular slots: {normalSlots.Count} ({_slotController.ElectricCountAndSort(normalSlots)} of which offers electric charging)", new UserOption.OptionFunctionSlots(TicketMachine.ParkOrder), normalSlots),
                new UserOption($"Handicap slots: {handicapSlots.Count}", new UserOption.OptionFunctionSlots(TicketMachine.ParkOrder), handicapSlots),
                new UserOption($"Large slots (bus/lorry): {largeSlots.Count}", new UserOption.OptionFunctionSlots(TicketMachine.ParkOrder), largeSlots),
                new UserOption($"Trailer slots: {trailerSlots.Count}", new UserOption.OptionFunctionSlots(TicketMachine.ParkOrder), trailerSlots)
            }, "Check In");
            option.Execute();
        }

        public static void ParkCheckOut()
        {
            int id = UserInteraction.GetInt("Check Out", "Enter ticket ID");
            ISlotTicket ticket = _ticketController.GetSlotTicketById(id);
            if (ticket != null)
            {
                _ticketController.CheckOutSlotTicket(ticket, _slotController);
                Console.WriteLine("Successful checkout.");
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }

        public static void ParkOrder(List<ISlot> slots)
        {
            bool electric = false;
            if (slots.Any(x => x.HasCharger == true))
                electric = UserInteraction.YesNo("Electric charging (FREE)");
            
            bool service = UserInteraction.YesNo("Service (Requires parking in up to 48 hours) (+479,99 kr.)");
            
            foreach (ISlot slot in slots)
            {
                if (_ticketController.NewSlotTicket(slot, electric, service, out ITicket ticket, _slotController))
                {
                    RegisterNewTicket(ticket);
                    break;
                }
            }
        }

        // Wash
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
            IWashTicket ticket = _ticketController.GetWashTicketById(id);
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

        public static void WashStatistics()
        {
            List<IPrintable> options = new List<IPrintable>();
            foreach (int carWashId in _washController.GetCarWashIds())
            {
                options.Add(new UserOption($"Show: Car wash #{carWashId}", new UserOption.OptionFunctionNumber(TicketMachine.WashPrintStatistics), carWashId));
                options.Add(new UserOption($"Update: Car wash #{carWashId}", new UserOption.OptionFunctionNumber(TicketMachine.WashGetStatistics), carWashId));
            }
            
            UserOption option = (UserOption)UserInteraction.SelectOption(options);
            option.Execute();
        }

        public static void WashGetStatistics(int carWashId)
        {
            Console.WriteLine($"Generating statistics for car wash #{carWashId} now.");
            
            Task<Dictionary<string,string>> task = _washController.GetStatisticsAsync(carWashId);

            if (_washStatistics.ContainsKey(carWashId))
                _washStatistics[carWashId] = task;
            else
                _washStatistics.Add(carWashId, task);
        }

        public static void WashPrintStatistics(int carWashId)
        {
            if (_washStatistics.ContainsKey(carWashId))
            {
                if (_washStatistics[carWashId].IsCompleted)
                    _washController.PrintStatistics(_washStatistics[carWashId].Result);
                else
                    Console.WriteLine($"Statistics for car wash #{carWashId} is currently being generated or updated. Nothing to show yet.");
            }
            else
            {
                Console.WriteLine($"There's no statistics for car wash #{carWashId}.");
                WashGetStatistics(carWashId);
            }
        }

        // General
        public static void RegisterNewTicket(ITicket ticket)
        {
            if (_ticketController.AddTicket(ticket))
                (ticket as IPrintable).PrintToConsole();
        }
    }
}
