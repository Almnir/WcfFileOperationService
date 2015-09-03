using Rikrop.Core.Wcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WcfFileService
{
    public class WcfHoster
    {
        private readonly ServiceHostManager _serviceHostManager;

        public WcfHoster(ServiceHostManager serviceHostManager)
        {
            _serviceHostManager = serviceHostManager;
        }

        public void Start()
        {
            var assembly = Assembly.GetExecutingAssembly();
            _serviceHostManager.StartServices(assembly);
        }

        public void Stop()
        {
            _serviceHostManager.StopServices();
        }
    }
}
