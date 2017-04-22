using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ServiceModel;


namespace BackupDaemon
{
    public static class Core
    {
        public static string DaemonName = "Test";

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
            foreach(string line in cLines)            
                if (string.IsNullOrWhiteSpace(line) || line.Contains("//"))                
                    cLines.Remove(line);
            ConfigSolver cSolver = new ConfigSolver(cLines);
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
            wAddress = new EndpointAddress("http://localhost:42867/Service1.svc");
            WriteToLog("Attempting to connect to: " + wAddress.ToString());
            wChannelFac = new ChannelFactory<ServerReference.IService1>(wBinding, wAddress);   

            wClient = wChannelFac.CreateChannel(); 
        }



    }
}
