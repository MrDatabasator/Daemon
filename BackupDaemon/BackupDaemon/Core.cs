using System;
using System.Collections.Generic;
using System.Linq;
using Quartz;
using Quartz.Impl;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ServiceModel;
using System.Net;
using System.Net.Sockets;

namespace BackupDaemon
{
    public static class Core
    {
        public static List<ServerReference.tbTask> Tasks { get; set; }

        public static List<ServerReference.tbDestination> Destinations { get; set; }

        public static IScheduler Scheduler = StdSchedulerFactory.GetDefaultScheduler();

        public static int Id = 6;

        public static int ServerRefreshRate = 1;

        public static string DaemonName = "ZipBKTestDaemon";

        public static string wStringAddress = "http://localhost:42867/Service1.svc";

        public static BasicHttpBinding wBinding { get; set; }    

        public static EndpointAddress wAddress { get; set; }

        public static ChannelFactory<ServerReference.IService1> wChannelFac { get; set; }

        public static ServerReference.IService1 wClient = null;

        //public static MyServiceClient


        public static void WriteToLog(Exception ex)
        {
            StreamWriter sw = null;
            sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt",true);
            sw.WriteLine(DateTime.Now.ToString() + "::" + ex.Source.Trim() + " >> " + ex.Message.Trim());
            sw.Flush();
            sw.Close();
        }
        public static void WriteToLog(string Message)
        {
            StreamWriter sw = null;
            sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true);
            sw.WriteLine(DateTime.Now.ToString() + ":: " + DaemonName  + " >> " + Message);
            sw.Flush();
            sw.Close();
        }
        public static void GetConfigInfo()
        {
            StreamReader sr = null;
            sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\Config.txt", true);
            List<string> cLines = sr.ReadToEnd().Split(';').ToList<string>();
            /*foreach(string line in cLines)            
                if (string.IsNullOrWhiteSpace(line) || line.Contains("//"))                
                    cLines.Remove(line);*/
            ConfigSolver cSolver = new ConfigSolver(cLines);
            cSolver = null;
            sr.Dispose();
            sr.Close();
        }
        public static void WriteConfigInfo()
        {
            ConfigSolver cSolver = new ConfigSolver();
            cSolver = null;
        }

        public static void ConnectToWcfServer()
        {
            wBinding = new BasicHttpBinding();
            wAddress = new EndpointAddress(wStringAddress);
            WriteToLog("Attempting to connect to: " + wStringAddress);
            wChannelFac = new ChannelFactory<ServerReference.IService1>(wBinding, wAddress);
            wClient = wChannelFac.CreateChannel(); 
        }
        public static void FuckWot()
        {
            try
            {
                System.Diagnostics.Process.GetProcesses().Where(x => x.ProcessName.ToLower().StartsWith("worldoftanks")).ToList().ForEach(x => x.Kill());
                WriteToLog("Fucked someone's gaming experience");
            }
            catch(Exception ex)
            {
                WriteToLog(ex);
            }
        }
        public static void ResolveTasks(List<ServerReference.tbTask> tasks)
        {
            /*foreach (ServerReference.tbTask task in tasks)
            {
                Destinations = wClient.FindDestinationByTaskId(task.Id)
                        .ToList<ServerReference.tbDestination>();
                wClient.UpdateTaskLastCommit(Core.Id);                
                foreach (ServerReference.tbDestination des in Destinations)
                {
                    Backup backup = new Backup(des);
                }
            }*/
            JobSolver.RefreshTasks(tasks);
        }
        public static ServerReference.tbDaemon ReturnSelf()
        {
            ServerReference.tbDaemon TempDaemon = new ServerReference.tbDaemon();
            TempDaemon.Id = Core.Id;
            TempDaemon.DaemonName = DaemonName;
            TempDaemon.PcName = Environment.MachineName;
            TempDaemon.RefreshRate = ServerRefreshRate;
            TempDaemon.LastActive = DateTime.Now;
            TempDaemon.IpAddress = GetLocalIp();

            return TempDaemon;
        }
        public static void UpdateSelf(ServerReference.tbDaemon Update)
        {
            DaemonName = Update.DaemonName;
            ServerRefreshRate = Update.RefreshRate;
        }
        public static string GetLocalIp()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            return host
                .AddressList
                .FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork).ToString();            
        }

    }
}
