using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfFileOperationService
{
    /// <summary>
    /// Интерфейс загрузки файлов
    /// </summary>
    [ServiceContract]
    public interface IUpload
    {
        /// <summary>
        /// Асинхронный старт загрузки файлов
        /// </summary>
        /// <param name="dataInfo"></param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        [OperationContract(AsyncPattern = true)]
        [FaultContract(typeof(UploadFault))]
        IAsyncResult BeginUploading(DataInfo dataInfo, AsyncCallback callback, object state);
        UploadResult EndUploading(IAsyncResult asyncResult);
        public async Task<UploadResult> UploadingAsync(DataInfo dataInfo);
    }
}
