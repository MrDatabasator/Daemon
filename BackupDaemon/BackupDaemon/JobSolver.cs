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

        private static List<ServerReference.tbTask> Tasks = new List<ServerReference.tbTask>();
        private static List<int> TaskIds = new List<int>();



        public static void RefreshTasks(List<ServerReference.tbTask> tasks)
        {
            
            List<ServerReference.tbTask> NewTasks = new List<ServerReference.tbTask>();
            foreach(ServerReference.tbTask task in tasks)
            {
                if(!TaskIds.Contains(task.Id))
                {                    
                    NewTasks.Add(task);
                    TaskIds.Add(task.Id);
                }
            }
            Tasks.AddRange(NewTasks);
            Core.ConnectToWcfServer();
            ResolveTasks(NewTasks);
            Core.wChannelFac.Close();
        }
        static void ResolveTasks(List<ServerReference.tbTask> tasks)
        {
            foreach (ServerReference.tbTask task in tasks)
            {
                foreach(ServerReference.tbDestination des in Core.wClient.FindDestinationByTaskId(task.Id))
                {
                    AddJobToScheduler(des, task.KornExpression);
                }
            }
                
        }
        static void AddJobToScheduler(ServerReference.tbDestination des, string cron)
        {
            IJobDetail TaskJob = JobBuilder.Create<BackupJob>()
                .WithIdentity("backupjob", "group1")
                .Build();

            TaskJob.JobDataMap.Put("instance", des);

            ITrigger TaskTrigger = TriggerBuilder.Create()
                .WithIdentity("backuptrigger", "group1")
                .StartNow()
                .WithCronSchedule(cron)
                .Build();

            Core.Scheduler.ScheduleJob(TaskJob, TaskTrigger);
        }
    }
}
