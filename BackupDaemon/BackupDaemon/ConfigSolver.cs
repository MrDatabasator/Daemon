﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.IO;

namespace BackupDaemon
{
    public class ConfigSolver
    {
        private List<string> Lines { get; set; }
        public ConfigSolver(List<string> lines)
        {
            Lines = lines;
            foreach(string line in Lines)
            {
                configSet(line);
            }
        }
        public ConfigSolver()
        {
            configWrite();
        }
        
        public void configSet(string Line)
        {
            string temp = Line;
            if(Line.ToLower().Contains("daemonname"))
            {
                Core.DaemonName = temp.Replace(" ", "").Split('=')[1];
            }
            else if(Line.ToLower().Contains("serveraddress"))
            {
                Core.wStringAddress = temp.Replace(" ", "").Split('=')[1];
            }
            else if (Line.ToLower().Contains("serverrefreshrate"))
            {
                Core.ServerRefreshRate = Convert.ToInt32(temp.Replace(" ", "").Split('=')[1]);
            }
            else if (Line.ToLower().Contains("daemonid"))
            {
                Core.Id = Convert.ToInt32(temp.Replace(" ", "").Split('=')[1]);
            }
        }
        public void configWrite()
        {
            FileInfo fInfo = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "\\Config.txt");
            if (fInfo.Exists)
                fInfo.Delete();
            StreamWriter sw = null;
            sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Config.txt", true);

            sw.WriteLine("//Config File generated by and for BackupDaemon.");
            sw.WriteLine("DaemonId = " + Core.Id + "; //Do NOT change this!");
            sw.WriteLine("DaemonName = " + Core.DaemonName + ";");
            sw.WriteLine("ServerAddress = " + Core.wStringAddress + ";");
            sw.WriteLine("ServerRefreshRate = " + Core.ServerRefreshRate + ";");

            sw.Dispose();
            sw.Close();
        }
    }
}
