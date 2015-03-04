using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatClient.Lib
{
    public interface IRestClient
    {
        Task<string> GetRequest(string Url);
    }
}
