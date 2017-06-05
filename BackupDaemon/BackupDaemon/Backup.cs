using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Renci.SshNet;

namespace BackupDaemon
{
    public class Backup
    {
        ServerReference.Service1Client Client { get; set; }
        private ServerReference.tbDestination tbDestination { get; set; }

        public Backup(ServerReference.tbDestination dest)
        {
            tbDestination = dest;
            string _SourceFolder = dest.NetSourcePath;
            string _DestinationFolder = dest.NetDestinationPath;
            string _ServerAddress = dest.FtpServerAddress;

            if (dest.Type.ToLower() == "local")
                NetBackup(dest.NetSourcePath, dest.NetDestinationPath);
            else if (dest.Type.ToLower() == "ftp")
                FTPbackup(_SourceFolder, _DestinationFolder, _ServerAddress);
            else
                Console.WriteLine("Wrong Type of backup");
            
        }
        void UploadDirectory(SftpClient client, string localPath, string remotePath)
        {
            Console.WriteLine("Uploading directory {0} to {1}", localPath, remotePath);

            IEnumerable<FileSystemInfo> infos =
                new DirectoryInfo(localPath).EnumerateFileSystemInfos();
            foreach (FileSystemInfo info in infos)
            {
                if (info.Attributes.HasFlag(FileAttributes.Directory))
                {
                    string subPath = remotePath + "/" + info.Name;
                    if (!client.Exists(subPath))
                    {
                        client.CreateDirectory(subPath);
                    }
                    UploadDirectory(client, info.FullName, remotePath + "/" + info.Name);
                }
                else
                {
                    using (Stream fileStream = new FileStream(info.FullName, FileMode.Open))
                    {
                        Console.WriteLine(
                            "Uploading {0} ({1:N0} bytes)", info.FullName, ((FileInfo)info).Length);
                        client.UploadFile(fileStream, remotePath + "/" + info.Name);
                    }
                }
            }
        }
        public void SSHbackup(string hostname,string username, string password, string SourceFolder)
        {
            const int port = 22;

            Console.WriteLine("Creating client and connecting");
            Console.WriteLine("Beginning SSH backup on: "+ hostname );
            Core.WriteToLog("Beginning SSH backup on: " + hostname );
            using (var client = new SftpClient(hostname, port, username, password))
            {
                client.Connect();
                Console.WriteLine("Connected to {0}", hostname);

                using (var fileStream = new FileStream(SourceFolder, FileMode.Open))
                {
                    Console.WriteLine("Uploading {0} ({1:N0} bytes)",
                                        SourceFolder, fileStream.Length);
                    client.BufferSize = 4 * 1024; // bypass Payload error large files
                    client.UploadFile(fileStream, Path.GetFileName(SourceFolder));
                }
            }
        }
        void RecureDirectory(DirectoryInfo directory)
        {
            FileInfo[] files = null;
            DirectoryInfo[] subDirectories = null;
            files = directory.GetFiles("*.*");
            if (files != null)
            {
                foreach (FileInfo file in files)
                {
                    string fileName = file.Name;
                    FileStream fileStream = file.OpenRead();
                    byte[] fileContents = new byte[fileStream.Length];
                    fileStream.Read(fileContents, 0, (int)fileStream.Length);
                }
                subDirectories = directory.GetDirectories();
                foreach (DirectoryInfo dirInfo in subDirectories)
                {
                    RecureDirectory(dirInfo);
                }
            }
        }
        public void FTPbackup(string SourceFolder, string DestinationFolder, string ServerAddress)
        {
            Console.WriteLine("Beginning Ftp backup on: ftp://" + ServerAddress + "/" + DestinationFolder);
            Core.WriteToLog("Beginning Ftp backup on: ftp://" + ServerAddress + "/" + DestinationFolder);
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri("ftp://"+ ServerAddress + "/"+ DestinationFolder));

            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(tbDestination.FtpUsername, tbDestination.FtpPassword);

            StreamReader sourceStream = new StreamReader(SourceFolder);
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
            FileAttributes attr = File.GetAttributes(Source);

            //detect whether its a directory or file
            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
            {
                // Get the subdirectories for the specified directory.
                DirectoryInfo dir = new DirectoryInfo(Source);
                Console.WriteLine("Beginning new Local backup to:" + Target);
                Core.WriteToLog("Beginning new Local backup to: " + Target);
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
            else
            {
                FileInfo file = new FileInfo(Source);
                if (!file.Exists)
                {
                    throw new FileNotFoundException(
                        "Source file does not exist or could not be found: "
                        + Source);
                }
                Core.WriteToLog("Beginning new Local backup to: " + Target);
                Console.WriteLine("Beginning new Local backup to:" + Target);
                string temppath = Path.Combine(Target, file.Name);
                file.CopyTo(temppath, true);
                
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
