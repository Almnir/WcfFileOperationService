using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfFileService
{
    [ServiceContract]
    public interface IFileTransferService
    {

        [OperationContract()]
        void WcfUploadFile(ResponseFile response);

        [OperationContract]
        Task<ResponseFile> WcfDownloadFile(RequestFile request);
    }
}
