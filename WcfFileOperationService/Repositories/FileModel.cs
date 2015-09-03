using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfFileOperationService.Repositories
{
    public class FileModel
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string FullPath { get; set; }
        public long FileSize { get; set; }
        public DateTime DateTimeStamp { get; set; }
    }
}
