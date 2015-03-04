using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StatAgent
{
    public class Scheduler
    {
        /// <summary>
        /// Runs the work on the current thread after a task delay in milisecconds
        /// 
        /// </summary>
        /// <param name="work"></param>
        /// <param name="interval"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task RunSchedule(Action<CancellationToken> work, int interval, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    await Task.Delay(interval, cancellationToken);
                    work(cancellationToken);
                }
                catch (AggregateException ex)
                {
                    //throw if an exception is not a cancellation exception
                    if (ex.InnerExceptions.Any(e => !(e is TaskCanceledException)))
                    {
                        throw ex;
                    }
                }
            }
        }
    }
}
