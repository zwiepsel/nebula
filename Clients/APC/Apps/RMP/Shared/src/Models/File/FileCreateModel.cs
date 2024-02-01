using Microsoft.AspNetCore.Components.Forms;
using Nebula.Shared.Models;

namespace Nebula.Clients.APC.Apps.RMP.Shared.Models.File;

public class FileCreateModel : CreateModel
{
    public string Name { get; set; } = null!;
    public int FileTypeId { get; set; }
    public IBrowserFile? BrowserFile { get; set; }
}