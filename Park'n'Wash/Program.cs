using System;

namespace Park_n_Wash
{
    class Program
    {
        static private TicketMachine ticketMachine = new TicketMachine();
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ticketMachine.ListSlots();
        }
    }
}
