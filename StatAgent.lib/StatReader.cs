using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatAgent
{
    public class StatReader : IStatReader
    {
        private PerformanceCounter memCounter;
        private PerformanceCounter cpuCounter;
        public StatReader()
        {
            memCounter = new PerformanceCounter("Memory", "Available MBytes");
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time","_Total");
        }

        public long GetMemoryUse()
        {
            _checkDisposed();
            return memCounter.RawValue;
        }

        public int GetCpuUse()
        {
            _checkDisposed();
            var sample = cpuCounter.NextSample();
            return (int)cpuCounter.NextValue();
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

            if (memCounter != null)
            {
                memCounter.Dispose();
            }
            if (cpuCounter != null)
            {
                cpuCounter.Dispose();
            }
            if (disposing)
            {
                memCounter = null;
                cpuCounter = null;
            }
            _disposed = true;
        }
        private void _checkDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException("StatReader");
            }

        }
        ~StatReader()
        {
            Dispose(false);
        }
        #endregion IDisposable
    }
}
