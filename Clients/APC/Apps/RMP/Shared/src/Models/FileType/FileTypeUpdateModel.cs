using Nebula.Shared.Models;

namespace Nebula.Clients.APC.Apps.RMP.Shared.Models.FileType;

public class FileTypeUpdateModel : UpdateModel
{
    public string Name { get; set; } = null!;
}