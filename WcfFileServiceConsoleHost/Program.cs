using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfFileService;

namespace WcfFileServiceConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var serverContainer = new UnityContainer())
            {
                serverContainer.RegisterServerDependencies();

                var service = serverContainer.Resolve<WcfHoster>();
                service.Start();

                Console.WriteLine("Сервер запущен. Для остановки нажмите Enter.");
                Console.ReadLine();

                service.Stop();
            }
        }
    }
}
