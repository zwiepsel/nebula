using Nebula.Clients.APC.Apps.RMP.Shared.Models.FileType;
using Nebula.Clients.APC.Apps.RMP.Web.Data;
using Nebula.Shared.Clients.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Web.Repositories;

public class FileTypeRepository : BaseCrudRepository<FileTypeViewModel, FileTypeViewModel, FileTypeCreateModel, FileTypeUpdateModel>
{
    public FileTypeRepository(AppApi api) : base(api, "file-type")
    {
    }
}