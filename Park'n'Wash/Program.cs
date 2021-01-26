using System;
using System.Collections.Generic;

namespace Park_n_Wash
{
    class Program
    {
        static private TicketMachine _ticketMachine = new TicketMachine();

        static void Main(string[] args)
        {
            _ticketMachine.RunApplication();
        }
    }
}
