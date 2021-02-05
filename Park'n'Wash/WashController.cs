using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash
{
    class WashController
    {
        private CarWashRepository _carWashRepository;

        public WashController()
        {
            _carWashRepository = new CarWashRepository();
            Initialize();
        }

        private void Initialize()
        {
            _carWashRepository.Insert(new Wash.CarWash(0));
            _carWashRepository.Insert(new Wash.CarWash(1));
        }
    }
}
