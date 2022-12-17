using MediatR;

namespace Shared;

public class BaseDomainEvent : INotification
{
    public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
}