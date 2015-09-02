using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfFileOperationService.Repositories;

namespace WcfFileOperationService
{
    public interface IFilesRepository
    {
        void Add(FileModel file);

        void Update(FileModel file);

        void Remove(FileModel file);

        FileModel GetById(Guid id);

        FileModel GetByName(string name);

        ICollection<FileModel> GetByCategory(string category);
    }
}
