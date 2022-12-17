using Shared;
using Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Todos;

public class TodoList: BaseAuditableEntity, IAggregateRoot
{
    public string? Name { get; set; }

    public IList<TodoItem> Items { get; private set; } = new List<TodoItem>();

    public void AddItem(string title, string description)
    {
        Items.Add(new TodoItem(Id, title, description));
    }

}
