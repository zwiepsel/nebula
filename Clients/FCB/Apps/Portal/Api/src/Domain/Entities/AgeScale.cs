using Nebula.Shared.Api.Entities;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities
{
    public class AgeScale : Entity
    {
        public string Scale { get; set; } = null!;
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
    }
}