using Park_n_Wash.Slot;
using Park_n_Wash.Wash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash.Ticket
{
    class WashTicket : BusinessEntity, IWashTicket
    {
        public int Id { get; private set; }
        public IWash Wash { get; private set; }
        public bool HasWashed { get; set; }

        public WashTicket(int id, IWash wash)
        {
            Id = id;
            Wash = wash;
            HasWashed = false;
        }

        public string PrintableString() =>
            $"# ##\n" +
            $"# ##  Ticket: {Id}\n" +
            $"# ##\n" +
            $"# ##  Price: {Wash.Price} kr.\n" +
            $"# ##\n\n";

        public override bool Validate()
        {
            bool isValid = true;

            if (!Wash.IsValid) isValid = false;

            return isValid;
        }
    }
}
