using Park_n_Wash.Slot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Park_n_Wash.Common;

namespace Park_n_Wash
{
    public class UserOption : IPrintable
    {
        private OptionFunction _optionFunction;
        private OptionFunctionSlot _optionFunctionSlot;
        
        public delegate void OptionFunction();
        public delegate void OptionFunctionSlot(List<ISlot> slot);

        public string Text { get; set; }
        private List<ISlot> Slots { get; set; }

        private UserOption(string text)
        {
            Text = text;
        }
        public UserOption(string text, OptionFunction optionFunction) : this(text)
        {
            _optionFunction = optionFunction;
        }
        public UserOption(string text, OptionFunctionSlot optionFunctionSlot, List<ISlot> slots) : this(text)
        {
            _optionFunctionSlot = optionFunctionSlot;
            Slots = slots;
        }

        public void Execute()
        {
            if (_optionFunction != null)
                _optionFunction();
            else if (_optionFunctionSlot != null)
                _optionFunctionSlot(Slots);
        }

        public string PrintableString() =>
            Text;
    }
}
