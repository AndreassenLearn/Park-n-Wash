using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash.Wash
{
    class Wash : BusinessEntity, IWash
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public double Price { get; private set; }
        public List<IWashProcess> WashProcesses { get; private set; }

        public Wash (int id, string name, double price, List<IWashProcess> washProcesses)
        {
            Id = id;
            Name = name;
            Price = price;
            WashProcesses = washProcesses;
        }

        public override bool Validate()
        {
            bool isValid = true;

            if (Price < 0) isValid = false;
            if (WashProcesses.Count == 0) isValid = false;

            return isValid;
        }
    }
}
