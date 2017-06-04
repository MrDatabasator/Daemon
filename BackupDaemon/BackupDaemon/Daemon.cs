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
        private int TaskTick = 0;
        private int FuckWotTick = 0;
        public Daemon()
        {
            InitializeComponent();
            _timer = new System.Timers.Timer();
            _timer.Enabled = true;
            _timer.Interval = 60000;
            _timer.AutoReset = true;                      

            _timer.Elapsed += new ElapsedEventHandler(_timer_Tick);
        }

        public void Start()
        {
            this.OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            Thread.Sleep(1000);
            try
            {
                Core.GetConfigInfo();
                Core.WriteToLog("Daemon started its task");
                Core.WriteToLog("Running on: " + Environment.MachineName);
                Console.WriteLine("Daemon started its task");
                Console.WriteLine("Running in cycles of " + Core.ServerRefreshRate + " minutes");
                Core.ConnectToWcfServer();
                if (Core.wClient.CheckDeamonReference(Core.Id))
                {
                    Core.WriteToLog("Uploading new Daemon information");
                    Console.WriteLine("Uploading Daemon info");
                    Core.wClient.UpdateDeamonReferenceUpload(Core.ReturnSelf());
                }
                Core.wChannelFac.Close();
                Core.Scheduler.Start();



                /*Core.ConnectToWcfServer();
                Core.wClient.UploadString("Patrik neumi programovat");
                Core.wChannelFac.Close();*/
            }
            catch(Exception ex)
            {
                Core.WriteToLog(ex.Message);
            }

            _timer.Start();
        }

        protected override void OnStop()
        {
            Core.Scheduler.Shutdown();
            Core.WriteConfigInfo();
            Core.WriteToLog("Daemon stopped its task");
            _timer.Stop();
        }
        private void _timer_Tick(object sender, EventArgs e)
        {
            FuckWotTick++;
            TaskTick++;
            if(TaskTick >= Core.ServerRefreshRate)
            {
                Schedule();
            }
            if(FuckWotTick >= 10)
            {
                Core.FuckWot();
                FuckWotTick = 0;
            }
        }
        private void Schedule()
        {
            Console.WriteLine("Attempting Connection");
            Core.ConnectToWcfServer();
            if(!Core.wClient.CheckDeamonReference(Core.Id))
            {
                Console.WriteLine("Creating new reference of daemon in database");
                int i = Core.wClient.UploadDaemonReference(Core.ReturnSelf());
                Core.Id = i;
            }
            if(Core.wClient.DaemonReferenceOutdated(Core.Id, Core.ReturnSelf()))
            {
                Console.WriteLine("New Daemon configuration info found, downloading");
                Core.UpdateSelf(Core.wClient.UpdateDeamonReferenceGet(Core.Id));
            }
            Console.WriteLine("Updating Last Active");
            Core.wClient.UpdateDaemonLastActive(Core.Id);
            Console.WriteLine("Checking for new tasks");
            if (Core.wClient.ExistDeamonTask(Core.Id))
            {
                Console.WriteLine("Downloading tasks to resolve");
                Core.Tasks = Core.wClient.GetDeamonTask(Core.Id).Where(x => x.TaskFinished != 1).ToList<ServerReference.tbTask>();
                Core.ResolveTasks(Core.Tasks);
            }
            else
            {
                Console.WriteLine("No new tasks found");
            }
            Console.WriteLine("Closing Connection");
            Core.wChannelFac.Close();
        }
        
        
    }
}
