using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupDaemon
{
    public class Backup
    {
        ServerReference.Service1Client Client { get; set; }
        // private Destination Destination { get; set; }
        public Backup(/*Destination*/)
        {

        }

        public void SSHbackup()
        {

        }
        public void FTPbackup()
        {

        }
        public void NETbackupFile(string SourcePath, string TargetPath)
        {
            Client = new ServerReference.Service1Client();
                    
            try
            {
                System.IO.File.Copy(SourcePath, TargetPath, true);
            }
            catch (Exception)
            {
                Client.NewLogMessage(Core.Id, "Backup cannot copy file" + SourcePath + " to " + TargetPath);
            }            
        }
        public void NETbackupDirectory(string SourcePath, string TargetPath)
        {

            Client = new ServerReference.Service1Client();

           /* if (!System.IO.Directory.Exists(TargetPath))
            {
                System.IO.Directory.CreateDirectory(TargetPath);
            }*/

            //nemůže být move
            try
            {
                System.IO.Directory.Move(SourcePath, TargetPath);
            }
            catch (Exception)
            {
                Client.NewLogMessage(Core.Id, "Backup cannot copy directory" + SourcePath + " to " + TargetPath);
            }         
        }
    }
}
