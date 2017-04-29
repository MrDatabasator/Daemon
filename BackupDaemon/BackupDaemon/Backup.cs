using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupDaemon
{
    public class Backup
    {
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
            if (!System.IO.File.Exists(TargetPath))
            {
                System.IO.File.Create(TargetPath);
            }

                try
            {
                System.IO.File.Move(SourcePath, TargetPath);
            }
            catch (Exception)
            {

                throw;
            }            
        }
        public void NETbackupDirectory(string SourcePath, string TargetPath)
        {
            if (!System.IO.Directory.Exists(TargetPath))
            {
                System.IO.Directory.CreateDirectory(TargetPath);
            }

            try
            {
                System.IO.Directory.Move(SourcePath, TargetPath);
            }
            catch (Exception)
            {

                throw;
            }         
        }
    }
}
