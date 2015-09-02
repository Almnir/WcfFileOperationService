using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfFileOperationService
{
    [DataContract]
    public class UploadFault
    {
        [DataMember]
        public string Message { get; set; }
    }
}
