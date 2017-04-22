using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;

namespace BackupDaemon
{
    public partial class Daemon : ServiceBase
    {
        private System.Timers.Timer _timer { get; set; }
        public Daemon()
        {
            InitializeComponent();
            _timer = new System.Timers.Timer();            
        }

        protected override void OnStart(string[] args)
        {
            Thread.Sleep(10000);
            try
            {
                Core.GetConfigInfo();
                Core.WriteToLog("Daemon started its task");
                Core.WriteToLog("Running on: " + Environment.MachineName);

            
                Core.ConnectToWcfServer();
                Core.wClient.UploadString("Patrik neumi programovat");
                Core.wChannelFac.Close();
            }
            catch(Exception ex)
            {
                Core.WriteToLog(ex.Message);
            }

            _timer.Start();
        }

        protected override void OnStop()
        {
            Core.WriteConfigInfo();
            Core.WriteToLog("Daemon stopped its task");
            _timer.Stop();
        }
    }
}
