using Nebula.Core.Api.Domain.Entities.Identity;
using Nebula.Shared.Api.Entities;

namespace Nebula.Core.Api.Domain.Entities;

public interface IEntity : IBaseEntity
{
    public User? DeletedBy { get; set; }
    public User? UpdatedBy { get; set; }
    public User CreatedBy { get; set; }
}