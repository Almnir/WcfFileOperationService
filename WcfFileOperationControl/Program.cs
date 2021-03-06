﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using WcfFileOperationService;

namespace WcfFileOperationControl
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            var svcHost = new ServiceHost(typeof(Upload));
            Console.WriteLine("Available Endpoints :\n");
            svcHost.Description.Endpoints.ToList().ForEach
             (endpoints => Console.WriteLine(endpoints.Address.ToString()));
            svcHost.Open();
            Console.ReadLine();
        }
    }
}
