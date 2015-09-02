using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfFileOperationService
{
    public class Upload : IUpload
    {
        /// <summary>
        /// Асинхронный метод старта з агрузки
        /// </summary>
        /// <param name="dataInfo"></param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public IAsyncResult BeginUploading(DataInfo dataInfo, AsyncCallback callback, object state)
        {
            // коллбэк завершения
            var tcs = new TaskCompletionSource<UploadResult>(state);
            var task = UploadingAsync(dataInfo);
            task.ContinueWith(t =>
            {
                if (t.IsFaulted)
                    tcs.TrySetException(t.Exception.InnerExceptions);
                else if (t.IsCanceled)
                    tcs.TrySetCanceled();
                else
                    tcs.TrySetResult(t.Result);

                if (callback != null)
                    callback(tcs.Task);
            });

            return tcs.Task;
        }

        /// <summary>
        /// Метод паттерна асинхронной обработки пробрасывающий результат
        /// </summary>
        /// <param name="asyncResult"></param>
        /// <returns></returns>
        public UploadResult EndUploading(IAsyncResult asyncResult)
        {
            try
            {
                return ((Task<UploadResult>)asyncResult).Result;
            }
            catch (AggregateException ex)
            {
                throw ex.InnerException;
            }
        }

        /// <summary>
        /// Асинхронная загрузка файлов созданием нового таска
        /// </summary>
        /// <param name="dataInfo"></param>
        /// <returns></returns>
        public async Task<UploadResult> UploadingAsync(DataInfo dataInfo)
        {
            try
            {
                // функция загрузки
                Func<UploadResult> uploadFunc = new Func<UploadResult>(() => UploadFiles(dataInfo));
                // создание таска фабрикой
                Task<UploadResult> returnTaskObject = Task.Factory.StartNew<UploadResult>(uploadFunc);
                // асинхронный запуск таска с результатом
                var result = await returnTaskObject;
                return result;
            }
            catch (Exception)
            {
                throw new FaultException<UploadFault>(new UploadFault { Message = "Ошибка загрузки" });
            }
        }

        /// <summary>
        /// Метод, загружающий файлы
        /// </summary>
        /// <param name="dataInfo"></param>
        /// <returns></returns>
        private UploadResult UploadFiles(DataInfo dataInfo)
        {
            UploadResult result = new UploadResult();

            // TODO: вынести в настройки
            string FilePath = Path.Combine("d:/Files/2015/", dataInfo.FileName);

            int length = 0;
            using (FileStream writer = new FileStream(FilePath, FileMode.Create))
            {
                int readCount;
                var buffer = new byte[8192];
                while ((readCount = dataInfo.Stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    writer.Write(buffer, 0, readCount);
                    length += readCount;
                }
            }

            return result;
        }
    }
}
