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
            string Ftp = "ftp://66.220.9.50:21/FTP/";
            string File = "FTP.txt";

            if (dest.Type.ToLower() == "net")
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
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(A + F));

            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential("MrDatabasator", "nedamheslo");

            StreamReader sourceStream = new StreamReader("FTP.txt");
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
