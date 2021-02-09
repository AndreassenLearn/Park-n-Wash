using Park_n_Wash.Slot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Park_n_Wash.Common;
using Park_n_Wash.Ticket;

namespace Park_n_Wash
{
    public class UserOption : IPrintable
    {
        private OptionFunction _optionFunction;
        private OptionFunctionNumber _optionFunctionNumber;
        private OptionFunctionSlots _optionFunctionSlots;
        private OptionFunctionTicket _optionFunctionTicket;
        
        public delegate void OptionFunction();
        public delegate void OptionFunctionNumber(int number);
        public delegate void OptionFunctionSlots(List<ISlot> slots);
        public delegate void OptionFunctionTicket(ITicket ticket);

        public string Text { get; set; }
        private int Number { get; set; }
        private List<ISlot> Slots { get; set; }
        private ITicket Ticket { get; set; }

        private UserOption(string text)
        {
            Text = text;
        }
        public UserOption(string text, OptionFunction optionFunction) : this(text)
        {
            _optionFunction = optionFunction;
        }
        public UserOption(string text, OptionFunctionNumber optionFunctionNumber, int number) : this(text)
        {
            _optionFunctionNumber = optionFunctionNumber;
            Number = number;
        }
        public UserOption(string text, OptionFunctionSlots optionFunctionSlots, List<ISlot> slots) : this(text)
        {
            _optionFunctionSlots = optionFunctionSlots;
            Slots = slots;
        }
        public UserOption(string text, OptionFunctionTicket optionFunctionTicket, ITicket ticket) : this(text)
        {
            _optionFunctionTicket = optionFunctionTicket;
            Ticket = ticket;
        }

        /// <summary>
        /// Execute the associated function.
        /// </summary>
        public void Execute()
        {
            if (_optionFunction != null)
                _optionFunction();
            else if (_optionFunctionNumber != null)
                _optionFunctionNumber(Number);
            else if (_optionFunctionSlots != null)
                _optionFunctionSlots(Slots);
            else if (_optionFunctionTicket != null)
                _optionFunctionTicket(Ticket);
        }

        public string PrintableString() =>
            Text;
    }
}
