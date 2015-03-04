using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatAgent
{
    public static class StatReaderFactory
    {
        public static IStatReader BuildStatReader()
        {
            return new StatReader();
        }
    }
}
