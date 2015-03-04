using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StatAgent
{
    public class AgentController : IDisposable
    {
        private bool running;
        IStatReader statReader;
        IStatPersist persist;
        CancellationTokenSource schedulerCancelSource; 

        
        /// <summary>
        /// This is the meat and potatos of the agent
        /// </summary>
        public void Start(int interval = 1000)
        {
            if (running)
                return;
            schedulerCancelSource = new CancellationTokenSource();
            running = true;
            //Create the persist object
            persist = StatPersistFactory.GetStatPersist();
            statReader = StatReaderFactory.BuildStatReader();
            Scheduler scheduler = new Scheduler();

            Task.Run(() => scheduler.RunSchedule(doWork, interval, schedulerCancelSource.Token), schedulerCancelSource.Token);
        }

        private void doWork(CancellationToken cancel)
        {
            DateTime time = DateTime.Now;
            ServerDataPoint memory = new ServerDataPoint()
            {
                Name = "Memory",
                Value = statReader.GetMemoryUse().ToString(),
                Time = time
            };
            persist.SaveDataRecord(memory);
            ServerDataPoint cpu = new ServerDataPoint()
            {
                Name = "Processor",
                Value = statReader.GetCpuUse().ToString(),
                Time = time
            };
            persist.SaveDataRecord(cpu);
        }

        public void Stop()
        {
            if (schedulerCancelSource != null)
            {
                schedulerCancelSource.Cancel();
                schedulerCancelSource.Dispose();
                schedulerCancelSource = null;
            }
            running = false;           
        }

        #region IDisposable members
        private bool _disposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (schedulerCancelSource != null)
            {
                schedulerCancelSource.Cancel();
                schedulerCancelSource.Dispose();
            }
            if (persist != null)
                persist.Clear();            
            if (statReader != null)
                statReader.Dispose();
            if (disposing)
            {
                persist = null;
                statReader = null;
                schedulerCancelSource = null;
            }
            _disposed = true;
        }
        private void _checkDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException("AgentController");
            }

        }
        ~AgentController()
        {
            Dispose(false);
        }
        #endregion IDisposable

    }
}
