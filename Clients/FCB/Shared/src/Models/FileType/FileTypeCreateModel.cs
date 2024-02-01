using Nebula.Shared.Models;

namespace Nebula.Clients.FCB.Shared.Models.FileType;

public class FileTypeCreateModel : CreateModel
{
    public string Name { get; set; } = null!;
}