using System;
using Quartz;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupDaemon
{
    public class BackupJob : IJob
    {
        private ServerReference.tbDestination Destination { get; set; }

        public void Execute(IJobExecutionContext context)
        {
            var dataMap = context.MergedJobDataMap;
            Destination = (ServerReference.tbDestination)dataMap["instance"];
            Core.ConnectToWcfServer();
            SolveDestinationAndBackup();
            Core.wChannelFac.Close();
        }

        private void SolveDestinationAndBackup()
        {
            if(Destination != null)
            {
                if(string.IsNullOrWhiteSpace(Destination.Type))
                {
                    Core.wClient.NewLogMessage(Core.Id, "Could not resolve Backup destination information");
                    Core.WriteToLog("Could not backup. Destination info incomplete");
                }
                else
                {
                    Core.wClient.NewLogMessage(Core.Id, "Initiating new  " + Destination.Type);
                    Core.WriteToLog("Initiating new  " + Destination.Type);
                    Backup backup = new Backup(Destination);                    
                }               
            }
        }     
        
    }
}
