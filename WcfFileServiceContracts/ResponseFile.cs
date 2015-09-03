using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfFileService
{
    [MessageContract]
    public class ResponseFile : IDisposable
    {
        [MessageHeader]
        public string FileName;

        [MessageHeader]
        public long Length;

        [MessageBodyMember]
        public System.IO.Stream FileByteStream;

        [MessageHeader]
        public long byteStart = 0;

        public void Dispose()
        {
            if (FileByteStream != null)
            {
                FileByteStream.Close();
                FileByteStream = null;
            }
        }
    }
}
