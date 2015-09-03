using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfFileService
{
    public class TransferService
    {
        public async Task<ResponseFile> StartDownloadFile(RequestFile request)
        {
            return await Task.Run(() => DownloadFile(request));
        }

        private ResponseFile DownloadFile(RequestFile request)
        {
            ResponseFile result = new ResponseFile();

            FileStream stream = this.GetFileStream(Path.GetFullPath(request.FileName));
            stream.Seek(request.byteStart, SeekOrigin.Begin);
            result.FileName = request.FileName;
            result.Length = stream.Length;
            result.FileByteStream = stream;
            return result;

        }

        private FileStream GetFileStream(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);

            if (!fileInfo.Exists)
                throw new FileNotFoundException("File not found");

            return new FileStream(filePath, FileMode.Open, FileAccess.Read);
        }

        public async Task StartUploadFile(ResponseFile response)
        {
            await Task.Run(() => UploadFile(response));
        }

        public void UploadFile(ResponseFile response)
        {

            string filePath = Path.GetFullPath(response.FileName);

            int chunkSize = 2048;
            byte[] buffer = new byte[chunkSize];

            using (FileStream stream = new FileStream(filePath, FileMode.Append, FileAccess.Write))
            {
                do
                {
                    int readbyte = response.FileByteStream.Read(buffer, 0, chunkSize);
                    if (readbyte == 0) break;

                    stream.Write(buffer, 0, readbyte);
                } while (true);
                stream.Close();
            }
        }

        public interface ICtor
        {
            TransferService Create();
        }
    }
}
