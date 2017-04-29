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
            System.IO.File.Move(SourcePath, TargetPath);
        }
        public void NETbackupDirectory(string SourcePath, string TargetPath)
        {
            System.IO.Directory.Move(SourcePath, TargetPath);

        }
    }
}
