using System.ComponentModel.DataAnnotations.Schema;

namespace Shared;

public abstract class BaseEntity
{
    public int Id { get; set; }
    
    [NotMapped]
    public List<BaseDomainEvent> DomainEvents { get; set; } = new();

    //protected void RegisterDomainEvent(BaseDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
    //internal void ClearDomainEvents() => _domainEvents.Clear();
}
