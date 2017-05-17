using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupDaemon
{
    public static class JobSolver
    {
        //private List<ServerReference.tbTask> Tasks { get; set; }

        private static List<ServerReference.tbTask> Tasks { get; set; }



        static void RefreshTasks(List<ServerReference.tbTask> NewTasks)
        {
            foreach(ServerReference.tbTask task in NewTasks)
            {
                if(!Tasks.Contains(task))
                {
                    Tasks.Add(task);
                }
            }
            ResolveTasks();
        }
        static void ResolveTasks()
        {
            
        }
    }
}
