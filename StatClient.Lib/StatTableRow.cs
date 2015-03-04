using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatClient.Lib
{
    public class StatTableRow
    {
        public DateTime Time { get; set; }
        public string Processor { get; set; }
        public string Memory { get; set; }
    }
}
