using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfFileService
{
    class FileTransferService : IFileTransferService
    {
        private readonly TransferService _transferService;

        public FileTransferService(TransferService.ICtor transferServiceCtor)
        {
            _transferService = transferServiceCtor.Create();
        }

        public async Task<ResponseFile> WcfDownloadFile(RequestFile request)
        {
            return await _transferService.StartDownloadFile(request);
        }

        public async Task WcfUploadFile(ResponseFile response)
        {
            return _transferService.StartUploadFile(response);
        }
    }
}
