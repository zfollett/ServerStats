using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace StatAgent
{
    [RunInstaller(true)]
    public class AgentInstaller : Installer
    {
        private ServiceInstaller service;
        private ServiceProcessInstaller proc;
        public AgentInstaller()
        {
            proc = new ServiceProcessInstaller();
            proc.Account = ServiceAccount.LocalSystem;            
            service = new ServiceInstaller();
            service.ServiceName = "1StatsAgentService";
            Installers.Add(proc);
            Installers.Add(service);
        }
    }
}
