using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;
using Nebula.Clients.FCB.Shared.Models.File;
using Nebula.Clients.FCB.Sites.MyFCB.Data;
using Nebula.Shared.Clients.Repositories;

namespace Nebula.Clients.FCB.Sites.MyFCB.Repositories;

public class PublicFileRepository : BaseRepository
{
    public PublicFileRepository(AppApi api) : base(api)
    {
    }

    public async Task<FileViewModel> Get(int fileId, CancellationToken cancellationToken = default)
    {
        return await Api.GetAsync<FileViewModel>($"file/{fileId}", cancellationToken);
    }
    
    public async Task<byte[]> GetFileContents(int fileId, CancellationToken cancellationToken = default)
    {
        var fileStream = await Api.GetStreamAsync($"file/{fileId}/file-contents", cancellationToken);
        var memoryStream = new MemoryStream();
        await fileStream.CopyToAsync(memoryStream, cancellationToken);

        return memoryStream.ToArray();
    }

    public async Task<FileViewModel> Create(IBrowserFile browserFile, FileCreateModel fileCreateModel,
        CancellationToken cancellationToken = default)
    {
        var streamContent = new StreamContent(browserFile.OpenReadStream(10240000, cancellationToken));
        using var content = new MultipartFormDataContent
        {
            { streamContent, "formFiles", browserFile.Name },
            { new StringContent(fileCreateModel.Name), "fileName" },
            { new StringContent(fileCreateModel.FileTypeId.ToString()), "fileTypeId" }
        };

        return await Api.PostAsync<FileViewModel>("public/file", content, cancellationToken);
    }

    public async Task Delete(int fileId, CancellationToken cancellationToken = default)
    {
        await Api.DeleteAsync($"file/{fileId}", cancellationToken);
    }
}