using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Nebula.Clients.FCB.Shared.Models.FileType;
using Nebula.Clients.FCB.Sites.MyFCB.Data;
using Nebula.Shared.Clients.Repositories;

namespace Nebula.Clients.FCB.Sites.MyFCB.Repositories;

public class PublicFileTypeRepository : BaseRepository
{
    public PublicFileTypeRepository(AppApi api) : base(api)
    {
    }
    
    public async Task<List<FileTypeViewModel>> Get(CancellationToken cancellationToken = default)
    {
        return await Api.GetAsync<List<FileTypeViewModel>>($"public/file-type", cancellationToken);
    }
}