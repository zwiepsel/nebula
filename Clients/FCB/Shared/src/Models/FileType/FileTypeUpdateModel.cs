using Nebula.Shared.Models;

namespace Nebula.Clients.FCB.Shared.Models.FileType;

public class FileTypeUpdateModel : UpdateModel
{
    public string Name { get; set; } = null!;
}