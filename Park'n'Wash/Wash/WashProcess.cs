using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash.Wash
{
    class WashProcess : BusinessEntity, IWashProcess
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public TimeSpan Duration { get; private set; }

        public WashProcess(int id, string name, TimeSpan duraton)
        {
            Id = id;
            Name = name;
            Duration = duraton;
        }

        public override bool Validate()
        {
            bool isValid = true;

            if (Duration < new TimeSpan(0)) isValid = false;

            return isValid;
        }
    }
}
