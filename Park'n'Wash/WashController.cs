using Park_n_Wash.Common;
using Park_n_Wash.Ticket;
using Park_n_Wash.Wash;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Park_n_Wash
{
    class WashController
    {
        private string _logFileName = "log_CarWash";
        private string _logFileExtension = ".csv";
        private string _logDelimiter = ";";
        
        private CarWashRepository _carWashRepository;
        private WashProcessRepository _washProcessRepository;
        private WashRepository _washRepository;

        private readonly Dictionary<int, CancellationTokenSource> _carWashCancelationTokenSources = new Dictionary<int, CancellationTokenSource>();

        public WashController()
        {
            _carWashRepository = new CarWashRepository();
            _washRepository = new WashRepository();
            _washProcessRepository = new WashProcessRepository();
            Initialize();
        }

        /// <summary>
        /// Get all car washes as <see cref="IPrintable"/>.
        /// </summary>
        /// <returns>List of <see cref="IPrintable"/>.</returns>
        public List<IPrintable> GetPrintableCarWashes()
        {
            List<IPrintable> printables = new List<IPrintable>();
            foreach (CarWash carWash in _carWashRepository.GetAll().ToList())
            {
                printables.Add(carWash);
            }

            return printables;
        }

        /// <summary>
        /// Start a <see cref="IWash"/> in soonest available <see cref="CarWash"/>.
        /// </summary>
        /// <param name="washTicket"><see cref="IWashTicket"/> to use.</param>
        /// <returns>False if <see cref="IWashTicket"/> already has been used; otherwise true.</returns>
        public bool StartCarWash(IWashTicket washTicket)
        {
            if (washTicket.HasWashed)
                return false;
            washTicket.HasWashed = true;

            // Get next free car wash.
            CarWash carWashToQueue = null;
            IEnumerable<CarWash> carWashes = _carWashRepository.GetAll();
            foreach (CarWash carWash in carWashes)
            {
                if (carWashToQueue != null && carWash.FinishAt < carWashToQueue.FinishAt || carWashToQueue == null)
                    carWashToQueue = carWash;
            }

            // Start car wash task.
            var token = GetNewCarWashCancelationTokenSource(carWashToQueue.Id).Token;
            
            Task carWashTask = new Task(() => carWashToQueue.StartWash(washTicket.Wash, token), token);
            Task canceledWashTask = carWashTask.ContinueWith((ant) =>
            {
                washTicket.HasWashed = false;
                Console.WriteLine($"{washTicket.Wash.Name} in car wash #{carWashToQueue.Id} has stopped.");
            }, TaskContinuationOptions.OnlyOnCanceled);
            Task writeLogTask = carWashTask.ContinueWith((ant) => WriteLog(carWashToQueue, washTicket, ant.Status));

            carWashTask.Start();

            return true;
        }

        /// <summary>
        /// Cancel running <see cref="CarWash"/>.
        /// </summary>
        /// <param name="id">ID of <see cref="CarWash"/>.</param>
        /// <returns>False if <see cref="CarWash"/> in not running or doesn't exists; otherwise true.</returns>
        public bool CancelCarWash(int id)
        {
            CarWash carWash = _carWashRepository.GetById(id);
            if (carWash == null && !carWash.IsRunning)
                return false;

            GetCarWashCancelationTokenSource(id).Cancel();

            return true;
        }

        /// <summary>
        /// Get <see cref="CancellationTokenSource"/> for <see cref="CarWash"/>. If it doesn't exist; add it.
        /// </summary>
        /// <param name="id">ID of <see cref="CarWash"/>.</param>
        /// <returns><see cref="CancellationTokenSource"/> for <see cref="CarWash"/> with given ID.</returns>
        private CancellationTokenSource GetCarWashCancelationTokenSource(int id)
        {
            if (!_carWashCancelationTokenSources.ContainsKey(id))
                _carWashCancelationTokenSources.Add(id, new CancellationTokenSource());
            
            return _carWashCancelationTokenSources[id];
        }

        /// <summary>
        /// Get new <see cref="CancellationTokenSource"/> for <see cref="CarWash"/>. If <see cref="CarWash"/>.Id doesn't exist in <see cref="_carWashCancelationTokenSources"/>; add it.
        /// </summary>
        /// <param name="id">ID of <see cref="CarWash"/>.</param>
        /// <returns><see cref="CancellationTokenSource"/> for <see cref="CarWash"/> with given ID.</returns>
        private CancellationTokenSource GetNewCarWashCancelationTokenSource(int id)
        {
            if (_carWashCancelationTokenSources.ContainsKey(id))
            {
                return _carWashCancelationTokenSources[id] = new CancellationTokenSource();
            }
            else
            {
                _carWashCancelationTokenSources.Add(id, new CancellationTokenSource());
                return _carWashCancelationTokenSources[id];
            }
        }

        // Wash
        /// <summary>
        /// Get all available washes.
        /// </summary>
        /// <returns>List of <see cref="IWash"/>.</returns>
        public List<IWash> GetWashes()
        {
            return _washRepository.GetAll().ToList();
        }

        // General
        /// <summary>
        /// Write log with ID's, status, and time information.
        /// </summary>
        /// <param name="carWash"><see cref="CarWash"/> to log.</param>
        /// <param name="washTicket"><see cref="IWashTicket"/> used for <see cref="CarWash"/>.</param>
        /// <param name="washStatus"><see cref="TaskStatus"/> from <see cref="Task"/> running car wash.</param>
        private void WriteLog(CarWash carWash, IWashTicket washTicket, TaskStatus washStatus)
        {
            string logFilePath = _logFileName + carWash.Id + _logFileExtension;
            
            StringBuilder stringBuilder = new StringBuilder();

            // If file doesn't exists; add headers.
            if (!File.Exists(logFilePath))
            {
                string[] headers = new string[] { "Time", "CarWash ID", "Ticket ID", "Wash ID", "Wash name", "Estimated finish time", "Wash status" };
                stringBuilder.AppendLine(string.Join(_logDelimiter, headers));
            }

            string[] content = new string[] { DateTime.Now.ToString(), carWash.Id.ToString(), washTicket.Id.ToString(), washTicket.Wash.Id.ToString(), washTicket.Wash.Name, carWash.FinishAt.ToString(), washStatus.ToString() };
            stringBuilder.AppendLine(string.Join(_logDelimiter, content));

            File.AppendAllText(logFilePath, stringBuilder.ToString());
        }

        /// <summary>
        /// Initialize repositories.
        /// </summary>
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
