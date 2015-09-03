using Rikrop.Core.Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WcfFileService;

namespace WcfFileServiceClient
{
    public class FileTransfer
    {
        private readonly IServiceExecutor<IFileTransferService> _serviceExecutor;

        public FileTransfer(IServiceExecutor<IFileTransferService> serviceExecutor)
        {
            _serviceExecutor = serviceExecutor;
        }

        public void Upload(ResponseFile response)
        {
            Task.Run(async () => await _serviceExecutor.Execute(s => s.WcfUploadFile(response)));
        }

        public ResponseFile Download(RequestFile request)
        {
            var tsk = Task.Run(async () => await _serviceExecutor.Execute(s => s.WcfDownloadFile(request)));
            return (ResponseFile)tsk.Result;
        }

        public interface ICtor
        {
            FileTransfer Create();
        }
    }
}
