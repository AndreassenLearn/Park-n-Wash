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

        //private Dictionary<PriceFormats, string> _priceFormats = new Dictionary<PriceFormats, string>
        //{
        //    { PriceFormats.None, "" },
        //    { PriceFormats.DKK, "DKK" },
        //    { PriceFormats.DKKPrHour, "DKK/h" }
        //};

        /// <summary>
        /// Defines formats for displaying a price.
        /// </summary>
        //public enum PriceFormats
        //{
        //    None,
        //    DKK,
        //    DKKPrHour
        //}

        public string Text { get; set; }
        private List<ISlot> Slots { get; set; }
        //public string SecondText { get; set; }
        //public int? Availability { get; set; }
        //public int? SecondAvailability { get; set; }
        //public double? Price { get; set; }
        //public PriceFormats PriceFormat { get; set; }

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

        //public UserOption(string text, double? price = null, PriceFormats priceFormat = PriceFormats.None, int? availability = null, string secondText = "", int? secondAvailablity = null)
        //{
        //    Text = text;
        //    Price = price;
        //    PriceFormat = priceFormat;
        //    Availability = availability;
        //    SecondText = secondText;
        //    SecondAvailability = secondAvailablity;
        //}

        public void Execute()
        {
            if (_optionFunction != null)
                _optionFunction();
            else if (_optionFunctionSlot != null)
                _optionFunctionSlot(Slots);
        }

        public string PrintableString() =>
            Text;
            //$"{Text}{(Availability != null ? ": " + Availability : "")}{(SecondText != "" ? " (" + SecondText + (SecondAvailability != null ? ": " + SecondAvailability : "") + ")" : "" )}{(Price != null ? " - " + String.Format("{0:0.00}", Price) + " " + _priceFormats[PriceFormat] : "")}";
    }
}
