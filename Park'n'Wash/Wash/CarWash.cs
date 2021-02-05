using Park_n_Wash.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash.Wash
{
    class CarWash : BusinessEntity, IBusinessEntity
    {
        public int Id { get; private set; }
        public bool IsWashing { get; private set; }

        public CarWash(int id)
        {
            Id = id;
        }



        public override bool Validate()
        {
            bool isValid = true;

            return isValid;
        }
    }
}
