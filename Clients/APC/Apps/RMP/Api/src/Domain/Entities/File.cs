using System.Collections.Generic;
using Nebula.Shared.Api.Entities;

namespace Nebula.Clients.APC.Apps.RMP.Api.Domain.Entities;

public class File : Entity
{
    public string Name { get; set; } = null!;
    public string OriginalName { get; set; } = null!;
    public string Path { get; set; } = null!;

    public int FileTypeId { get; set; }
    public virtual FileType FileType { get; set; } = null!;

    public virtual IList<Risk> Risks { get; set; } = null!;
    public virtual IList<MitigationControl> MitigationControls { get; set; } = null!;
}