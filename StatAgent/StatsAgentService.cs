using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace StatAgent
{
    public class StatsAgentService : ServiceBase
    {
        private ServiceHost serviceHost = null;
        private AgentController controller = null;
        public StatsAgentService()
        {
            this.ServiceName = "1StatsAgentService";
        }
        public static void Main()
        {
            ServiceBase.Run(new StatsAgentService());
        }
        protected override void OnStart(string[] args)
        {
            try
            {
                if (serviceHost != null)
                {
                    serviceHost.Close();
                }
                serviceHost = new ServiceHost(typeof(StatAgent.ServerStats));
                serviceHost.Faulted += serviceHost_Faulted;
                serviceHost.Open();    
                if(controller == null)
                {
                    controller = new AgentController();
                }                
                controller.Start();            
            }
            catch(Exception ex)
            {
                EventLog.WriteEntry("OnStart Exception" + ex.Message + ex.StackTrace, System.Diagnostics.EventLogEntryType.Error);
                cleanUp();
                this.Stop();
            }
        }

        void serviceHost_Faulted(object sender, EventArgs e)
        {
            EventLog.WriteEntry("ServiceHost Faulted " + e.ToString(), System.Diagnostics.EventLogEntryType.Error);
            cleanUp();
            this.Stop();
        }


        protected override void OnStop()
        {
            cleanUp();
        }

        private void cleanUp()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
            if (controller != null)
            {                
                controller.Dispose();
                controller = null;
            }
        }

    }
}
