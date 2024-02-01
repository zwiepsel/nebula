using Nebula.Clients.FCB.Apps.Portal.Web.Data;
using Nebula.Clients.FCB.Shared.Models.FileType;
using Nebula.Shared.Clients.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Web.Repositories;

public class FileTypeRepository : BaseCrudRepository<FileTypeViewModel, FileTypeViewModel, FileTypeCreateModel, FileTypeUpdateModel>
{
    public FileTypeRepository(AppApi api) : base(api, "file-type")
    {
    }
}