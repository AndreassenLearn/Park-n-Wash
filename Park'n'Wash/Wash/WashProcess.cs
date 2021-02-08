using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        /// <summary>
        /// Run <see cref="WashProcess"/> for <see cref="Duration"/>.
        /// </summary>
        /// <param name="carWashId">ID of <see cref="CarWash"/>.</param>
        /// <param name="token"><see cref="CancellationToken"/> to throw <see cref="OperationCanceledException"/> on cancel.</param>
        public void Run(int carWashId, CancellationToken token)
        {
            DateTime startTime = DateTime.Now;

            //Check time and cancellation token twice every second.
            do
            {
                token.ThrowIfCancellationRequested();
                Task.Delay(500);
            } while ((DateTime.Now - startTime) <= Duration);
        }

        public override bool Validate()
        {
            bool isValid = true;

            if (Duration < new TimeSpan(0)) isValid = false;

            return isValid;
        }
    }
}
