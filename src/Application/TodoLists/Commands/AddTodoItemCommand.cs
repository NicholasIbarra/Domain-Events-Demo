using Application.Common.Interfaces;
using Domain.Todos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TodoLists.Commands
{
    public record AddTodoItemCommand(int TodoListId, string? Title, string Description) : IRequest<int>;

    public class AddTodoItemCommandHandler : IRequestHandler<AddTodoItemCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public AddTodoItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddTodoItemCommand request, CancellationToken cancellationToken)
        {
            var list = _context.TodoLists.FirstOrDefault(i => i.Id == request.TodoListId);

            if (list == null)
                throw new NullReferenceException("Invalid request");

            list.AddItem(request.Title, request.Description);

            await _context.SaveChangesAsync(cancellationToken);

            return list.Id;
        }
    }
}
