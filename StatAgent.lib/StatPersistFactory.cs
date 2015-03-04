using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatAgent
{
    public static class StatPersistFactory
    {
        private static IStatPersist statPersist;
        public static IStatPersist GetStatPersist(List<string> fields = null)
        {
            if (statPersist == null)
            {
                if (fields == null)
                    fields = new List<string>();
                if (fields.Count == 0)
                {
                    fields.Add("Memory");
                    fields.Add("Processor");
                }
                statPersist = new PersistInMemory(fields);
            }
            return statPersist;
        }
    }
}
