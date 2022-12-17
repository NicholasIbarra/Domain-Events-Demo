using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Application.TodoLists.Queries;

public class TodosVm
{
    public string Name { get; set; }

    public IEnumerable<TodoItemsDto> Items { get; set; }
}

public class TodoItemsDto
{
    public string Title { get; set; }
}

public record GetTodoListsQuery: IRequest<IEnumerable<TodosVm>>;

public class GetTodoListQueryHandler : IRequestHandler<GetTodoListsQuery, IEnumerable<TodosVm>>
{

    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTodoListQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TodosVm>> Handle(GetTodoListsQuery request, CancellationToken cancellationToken)
    {
        var results = await _context.TodoLists.Include(i => i.Items).ToListAsync();

        return results.Select(i => new TodosVm
        {
            Name = i.Name ?? string.Empty,
            Items = i.Items.Select(t => new TodoItemsDto
            {
                Title = t.Title
            })
        });
    }
}

