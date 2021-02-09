using Park_n_Wash.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Park_n_Wash.Wash
{
    class CarWash : BusinessEntity, IBusinessEntity, IPrintable
    {
        private int _queueCount = 0;
        
        public int Id { get; private set; }
        public bool IsRunning
        {
            get { return CurrentWashProcess != null; }
        }
        public DateTime FinishAt { get; private set; }
        public IWashProcess CurrentWashProcess { get; private set; }

        public CarWash(int id)
        {
            Id = id;
            FinishAt = DateTime.Now;
        }

        /// <summary>
        /// Start a wash in current <see cref="CarWash"/>.
        /// </summary>
        /// <param name="wash"></param>
        /// <param name="token"><see cref="CancellationToken"/> to throw <see cref="OperationCanceledException"/> on cancel.</param>
        public void StartWash(IWash wash, CancellationToken token)
        {
            bool acquiredLock = false;

            try
            {
                Monitor.TryEnter(this, 5000, ref acquiredLock);
                if (!acquiredLock)
                {
                    // If lock not acquired within 5 seconds; count up _queueCount, print message, and wait to enter without timeout.
                    Console.WriteLine($"Car wash #{Id} is currently running. You are number {++_queueCount} in the queue.\n" +
                        $"Estimated finish time for currently running wash is: {FinishAt}.");
                    Monitor.Enter(this, ref acquiredLock);
                    _queueCount--;
                }
                // Lock acquired.
                Console.WriteLine($"{wash.Name} in car wash #{Id} has started.");

                // Calculate and set finish time.
                TimeSpan totalDuration = new TimeSpan();
                foreach (IWashProcess washProcess in wash.WashProcesses)
                {
                    totalDuration = totalDuration.Add(washProcess.Duration);
                }
                FinishAt = DateTime.Now.Add(totalDuration);

                // Run wash.
                foreach (IWashProcess washProcess in wash.WashProcesses)
                {
                    CurrentWashProcess = washProcess;
                    washProcess.Run(Id, token);
                }
                CurrentWashProcess = null;

                Console.WriteLine($"{wash.Name} in car wash #{Id} has finished.");
            }
            finally
            {
                if (acquiredLock)
                {
                    Monitor.Exit(this);
                }
            }
        }

        public string PrintableString() =>
            $"ID: {Id}, Is running: {(IsRunning ? $"Y, Finished at: {FinishAt}, Current process: {(CurrentWashProcess != null ? CurrentWashProcess.Name : "N/A")}" : "N")}";

        public override bool Validate()
        {
            bool isValid = true;

            return isValid;
        }
    }
}
