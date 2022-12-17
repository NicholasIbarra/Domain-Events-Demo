using Domain.Todos.Events;
using Shared;

namespace Domain.Todos;

public class TodoItem : BaseAuditableEntity
{ 
    public int TodoListId { get; private set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int? ContributorId { get; private set; }

    public bool IsDone { get; private set; }

    public TodoItem(int todoListId, string title, string description)
    {
        TodoListId = todoListId;
        Title = title;
        Description = description;
        IsDone = false;
    }

    public void MarkComplete()
    {
        if (!IsDone)
        {
            IsDone = true;

            DomainEvents.Add(new TodoItemCompletedEvent(this));
        }
    }

    public void AddContributor(int contributorId)
    {
        //Guard.Against.Null(contributorId, nameof(contributorId));
        ContributorId = contributorId;

        //var contributorAddedToItem = new ContributorAddedToItemEvent(this, contributorId);
        //base.RegisterDomainEvent(contributorAddedToItem);
    }
}
