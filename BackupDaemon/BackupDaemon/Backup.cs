using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace BackupDaemon
{
    public class Backup
    {
        ServerReference.Service1Client Client { get; set; }
        private ServerReference.tbDestination tbDestination { get; set; }

        public Backup(ServerReference.tbDestination dest)
        {
            tbDestination = dest;
            string Ftp = dest.FtpServerAddress;
            string File = dest.NetDestinationPath;

            if (dest.Type.ToLower() == "local")
                NetBackup(dest.NetSourcePath, dest.NetDestinationPath);
            else if (dest.Type.ToLower() == "ftp")
                FTPbackup(Ftp, File);
            else
                Console.WriteLine("Wrong Type of backup");
            Console.ReadLine();

            
        }

        public void SSHbackup()
        {

        }
        public void FTPbackup(string A, string F)
        {
            Console.WriteLine("Beginning Ftp backup on: ftp://" + A + "/" + F);
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri("ftp://"+ A +"/"+ F));

            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(tbDestination.FtpUsername, tbDestination.FtpPassword);

            StreamReader sourceStream = new StreamReader(tbDestination.NetSourcePath);
            byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            sourceStream.Close();
            request.ContentLength = fileContents.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);

            response.Close();
        }
        public void NetBackup(string Source, string Target)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(Source);
            Console.WriteLine("Beginning new Local backup to:" + Target);
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + Source);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(Target))
            {
                Directory.CreateDirectory(Target);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(Target, file.Name);
                file.CopyTo(temppath, true);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (true)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(Target, subdir.Name);
                    NetBackup(subdir.FullName, temppath);
                }
            }
            Console.WriteLine("Local backup done");
        }
        /*
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

            if (!System.IO.Directory.Exists(TargetPath))
            {
                System.IO.Directory.CreateDirectory(TargetPath);
            }

            //nemůže být move
            try
            {
                System.IO.Directory.Move(SourcePath, TargetPath);
            }
            catch (Exception)
            {
                Client.NewLogMessage(Core.Id, "Backup cannot copy directory" + SourcePath + " to " + TargetPath);
            }         
        }*/
    }
}
