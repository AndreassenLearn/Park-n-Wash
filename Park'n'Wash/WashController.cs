﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash
{
    class WashController
    {
        private CarWashRepository _carWashRepository;
        private WashRepository _washRepository;
        private WashProcessRepository _washProcessRepository;

        public WashController()
        {
            _carWashRepository = new CarWashRepository();
            _washRepository = new WashRepository();
            _washProcessRepository = new WashProcessRepository();
            Initialize();
        }

        private void Initialize()
        {
            _carWashRepository.Insert(new Wash.CarWash(0));
            _carWashRepository.Insert(new Wash.CarWash(1));
        }
    }
}
