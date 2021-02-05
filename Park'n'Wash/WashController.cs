using Park_n_Wash.Wash;
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
        private WashProcessRepository _washProcessRepository;
        private WashRepository _washRepository;

        public WashController()
        {
            _carWashRepository = new CarWashRepository();
            _washRepository = new WashRepository();
            _washProcessRepository = new WashProcessRepository();
            Initialize();
        }

        public List<IWash> GetWashes()
        {
            return _washRepository.GetAll().ToList();
        }

        private void Initialize()
        {
            _carWashRepository.Insert(new CarWash(0));
            _carWashRepository.Insert(new CarWash(1));

            _washProcessRepository.Insert(new WashProcess(0, "Rinse", new TimeSpan(0, 0, 30)));
            _washProcessRepository.Insert(new WashProcess(1, "Wash", new TimeSpan(0, 2, 0)));
            _washProcessRepository.Insert(new WashProcess(2, "Undercarriage Wash", new TimeSpan(0, 1, 30)));
            _washProcessRepository.Insert(new WashProcess(3, "Dry", new TimeSpan(0, 1, 0)));
            _washProcessRepository.Insert(new WashProcess(4, "Wax", new TimeSpan(0, 0, 45)));

            List<IWashProcess> basicProcessList = new List<IWashProcess>()
            {
                _washProcessRepository.GetById(0),
                _washProcessRepository.GetById(1),
                _washProcessRepository.GetById(3)
            };

            List<IWashProcess> premiumProcessList = new List<IWashProcess>()
            {
                _washProcessRepository.GetById(0),
                _washProcessRepository.GetById(1),
                _washProcessRepository.GetById(2),
                _washProcessRepository.GetById(3)
            };

            List<IWashProcess> deluxeProcessList = new List<IWashProcess>()
            {
                _washProcessRepository.GetById(0),
                _washProcessRepository.GetById(1),
                _washProcessRepository.GetById(2),
                _washProcessRepository.GetById(3),
                _washProcessRepository.GetById(4)
            };

            _washRepository.Insert(new Wash.Wash(0, "Basic Wash", 69.99, basicProcessList));
            _washRepository.Insert(new Wash.Wash(1, "Premium Wash", 99.99, premiumProcessList));
            _washRepository.Insert(new Wash.Wash(2, "Deluxe Wash", 159.99, deluxeProcessList));
        }
    }
}
