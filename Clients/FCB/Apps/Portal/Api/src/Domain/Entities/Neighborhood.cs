using Nebula.Shared.Api.Entities;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities;

public class Neighborhood : Entity
{
    public string Name { get; set; } = null!;
    public int Valuation { get; set; }
    public int Points { get; set; }
}