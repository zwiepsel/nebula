using Nebula.Shared.Models;

namespace Nebula.Clients.APC.Apps.RMP.Shared.Models.FileType;

public class FileTypeCreateModel : CreateModel
{
    public string Name { get; set; } = null!;
}