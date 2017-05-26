using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackupDaemon
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
#if DEBUG
            Daemon d = new Daemon();
            Thread t = new Thread(new ThreadStart(d.Start));
            t.Start();
            Console.ReadKey();
#else
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Daemon()
            };
            ServiceBase.Run(ServicesToRun);
#endif
        }
    }
}
