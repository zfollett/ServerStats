using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatClient.Lib
{
    interface IStatDownloader
    {
        Task<List<StatTableRow>> GetStats(string ServerName, DateTime start);

    }
}
