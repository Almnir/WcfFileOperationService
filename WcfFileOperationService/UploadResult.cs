using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfFileOperationService
{
    public enum FileType { Packages = 1, Protocols = 2, Software = 3, Images = 4, Archive = 5, All = 254, Other = 255 };
    public enum Result { CanBeSaved = 1, CannotBeSaved = 2, Saved = 3, SavingError = 4, CanBeDeleted = 5, CannotBeDeleted = 6 };
    public enum FileOptions
    {
        FileExists = 1,
        FileAbsent = 2,
        Registered = 4,
        Unregistered = 8,
        Complected = 16,
        Converted = 32,
        Checked = 64,
        Scaled = 128,
        ReportSent = 256,
        TooManyRegistrations = 512,
        SameCrc = 1024,
        DifferCrc = 2048,
    }
    public enum ServiceMode { Online = 1, Maintenance = 2, ReadOnly = 3, DenyUsers = 4 }

    [DataContract]
    public class UploadResult
    {
        [DataMember]
        public Result Action;
        [DataMember]
        public FileType FileType;
        [DataMember]
        public Guid NewsId;
        [DataMember]
        public int ReceiverId;
        [DataMember]
        public bool UseReceiverFolder;
        [DataMember]
        public string FileName;
        [DataMember]
        public int ErrorCode;
        [DataMember]
        public string Error;
    }
}
