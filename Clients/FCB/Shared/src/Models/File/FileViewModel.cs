using Nebula.Clients.FCB.Shared.Enums;
using Nebula.Clients.FCB.Shared.Models.FileType;
using Nebula.Shared.Models;

namespace Nebula.Clients.FCB.Shared.Models.File;

public class FileViewModel : ViewModel
{
    public string Name { get; set; } = null!;
    public string OriginalName { get; set; } = null!;
    public FileUploadStatus Status { get; set; } = FileUploadStatus.InProgress;

    public FileTypeViewModel FileType { get; set; } = null!;
}