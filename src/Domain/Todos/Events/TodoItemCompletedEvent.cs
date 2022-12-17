using Shared;

namespace Domain.Todos.Events;

public class TodoItemCompletedEvent : BaseDomainEvent
{
    public TodoItemCompletedEvent(TodoItem item)
    {
        Item = item;
    }

    public TodoItem Item { get; }
}
