using System;
using System.Collections.Generic;

namespace Park_n_Wash
{
    class Program
    {
        static private TicketMachine ticketMachine = new TicketMachine();

        static void Main(string[] args)
        {
            Console.WriteLine("##### Welcome to Park'n'Wash #####");
            ticketMachine.ListSlots(out List<ISlot> normalSlots, out List<ISlot> handicapSlots, out List<ISlot> largeSlots, out List<ISlot> trailerSlots);
        }
    }
}
