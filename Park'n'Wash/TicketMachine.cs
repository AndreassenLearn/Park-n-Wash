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
            ITicket ticket = _ticketController.GetActiveTicketById(id) as IWashTicket; //ticket will be null if it's not an IWashTicket or it doesn't exist.
            if (ticket != null)
            {
                // TODO: Start wash in with an available CarWash.
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }

        public static void RegisterNewTicket(ITicket ticket)
        {
            _ticketController.AddTicket(ticket);

            (ticket as IPrintable).PrintToConsole();
        }
    }
}
