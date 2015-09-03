using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfFileService
{
    [MessageContract]
    public class RequestFile
    {
        [MessageBodyMember]
        public string FileName;

        [MessageBodyMember]
        public long byteStart = 0;
    }
}
