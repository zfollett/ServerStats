using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatAgent
{
    public interface IStatReader : IDisposable
    {
        long GetMemoryUse();
        int GetCpuUse();

    }
}
