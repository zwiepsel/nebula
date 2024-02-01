using Nebula.Shared.Api.Entities;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities;

public class File : Entity
{
    public string Name { get; set; } = null!;
    public string OriginalName { get; set; } = null!;
    public string Path { get; set; } = null!;
    public int? ClientId { get; set; }
    public virtual Client Client { get; set; }
    public int? RequestId { get; set; }
    public virtual Request Request { get; set; }
    public int FileTypeId { get; set; }
    public virtual FileType FileType { get; set; } = null!;
    
}