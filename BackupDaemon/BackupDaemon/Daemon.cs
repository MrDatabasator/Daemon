using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace BackupDaemon
{
    public partial class Daemon : ServiceBase
    {
        private Timer _timer { get; set; }
        public Daemon()
        {
            InitializeComponent();
            _timer = new Timer();            
        }

        protected override void OnStart(string[] args)
        {
            Core.WriteToLog("Daemon started its task");
            Core.WriteToLog("Running on: " + Environment.MachineName);

            try
            {
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
            Core.WriteToLog("Daemon stopped its task");
            _timer.Stop();
        }
    }
}
