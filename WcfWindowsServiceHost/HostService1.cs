using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using WcfServiceLibrary1;

namespace WcfWindowsServiceHost
{
    public partial class HostService1 : ServiceBase
    {
        ServiceHost selfHost = null;

        public HostService1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // Step 1 Create a URI to serve as the base address.
            Uri baseAddress = new Uri("http://localhost:8000/GettingStarted/");

            // Step 2 Create a ServiceHost instance
            selfHost = new ServiceHost(typeof(Service1), baseAddress);

            try
            {
                // Step 3 Add a service endpoint.
                selfHost.AddServiceEndpoint(typeof(ICalculator), new WSHttpBinding(), "CalculatorService");

                // Step 4 Enable metadata exchange.                
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);

                eventLog1.WriteEntry("Behavior count = " + selfHost.Description.Behaviors.Count);                

                // Step 5 Start the service.
                selfHost.Open();
                eventLog1.WriteEntry(this.ServiceName + " service is ready.");
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                selfHost.Abort();
            }
        }

        protected override void OnStop()
        {            
            // Close the ServiceHostBase to shutdown the service.
            selfHost.Close();
            eventLog1.WriteEntry(this.ServiceName + " service is stopped.");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            eventLog1.WriteEntry(this.ServiceName + " timer is coming");
        }
    }
}
