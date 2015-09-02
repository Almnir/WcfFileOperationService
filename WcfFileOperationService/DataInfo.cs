using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfFileOperationService
{
    [DataContract]
    public class DataInfo
    {
        [DataMember]
        public Guid SessionID;

        [DataMember]
        public string FileName;

        [DataMember]
        public long Length;

        [DataMember]
        public FileType FileType;

        [DataMember]
        public DateTime ClientDate;

        [DataMember]
        public bool UseReceiverFolder;

        [DataMember]
        public Stream Stream;
    }
}
