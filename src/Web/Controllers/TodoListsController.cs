using Application.TodoLists.Commands;
using Application.TodoLists.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoListsController : ControllerBase
{
    protected ISender _mediator;

    public TodoListsController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var result = await _mediator.Send(new GetTodoListsQuery());

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult> Post(string title)
    {
        var result = await _mediator.Send(new CreateTodoListCommand(title));

        return Ok(result);
    }

    [HttpPost("Id")]
    public async Task<ActionResult> Items(int listId, string title, string description)
    {
        var result = await _mediator.Send(new AddTodoItemCommand(listId, title, description));

        return Ok(result);
    }

    [HttpPost("{listId}/Complete")]
    public async Task<ActionResult> Complete(int listId, int itemId)
    {
        var result = await _mediator.Send(new CompleteTodoItemCommand(listId, itemId));

        return Ok(result);
    }
}
